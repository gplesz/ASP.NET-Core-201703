using AutoMapper;
using FamilyPhotos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyPhotos.ViewModel
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PhotoModel, PhotoViewModel>()
                .ForMember(d=>d.PictureFromBrowser, o=>o.Ignore())
                ;
            CreateMap<PhotoViewModel, PhotoModel>()
                .ForMember(d=>d.ModifiedDate, o=>o.UseValue(DateTime.Today))
                .ForMember(d => d.CreatedDate, o => o.Ignore())
                .ForMember(d=>d.ContentType, o=>o.MapFrom(
                        s=>s.PictureFromBrowser == null 
                        ? null 
                        : s.PictureFromBrowser.ContentType))
                .AfterMap((vm, m) =>
                {
                    //Átírni az adatokat a model.PictureFromBrowser --> model.Picture
                    //Készítünk egy fogadó byte tömböt, amiben a kép elfér
                    m.Picture = new byte[vm.PictureFromBrowser.Length];

                    //Megnyitjuk és átmásoljuk a feltöltött állomány stream-jét a tömbbe
                    using (var stream = vm.PictureFromBrowser.OpenReadStream())
                    {
                        //figyelem, ehelyett a cast helyett buffer + ciklus, ez csak DEMO
                        stream.Read(m.Picture, 0, (int)vm.PictureFromBrowser.Length);
                    }
                })
                ;
        }
    }
}
