using AutoMapper;
using FamilyPhotos.Models;
using FamilyPhotos.Repository;
using FamilyPhotos.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyPhotos.Controllers
{
    public class PhotoController : Controller
    {
        private PhotoRepository repository;
        private IMapper mapper;

        public PhotoController(PhotoRepository repository, IMapper mapper)
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }
            this.repository = repository;

            if (mapper == null)
            {
                throw new ArgumentNullException(nameof(mapper));
            }
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var pics = repository.GetAllPhotos();
            return View(pics);
        }

        public FileContentResult GetImage(int photoId)
        {
            var pic = repository.GetPicture(photoId);
            if (pic==null || pic.Picture==null)
            {
                return null;
            }

            return File(pic.Picture, pic.ContentType);
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View(new PhotoViewModel());
        }

        [HttpPost]
        //public IActionResult Create(string Title, string Description)
        public IActionResult Create(PhotoViewModel viewModel) //Itt az MVC modelbindere a bejövő paramétereket egyezteti a várt osztály propertyjeivel és ki is tölti
        {
            //Ha a kontroller action model-t fogad, KÖTELEZŐ ellenőrizni a 
            //ModelState-et

            //nagyon kezdetleges Adatvalidálás, ezt majd jól meg fogjuk haladni!
            //hiányzik még pár dolog, csak DEMO

            if (!ModelState.IsValid
                || viewModel.PictureFromBrowser == null || viewModel.PictureFromBrowser.Length == 0)
            {
                return View(viewModel);
            }

            var model = mapper.Map<PhotoModel>(viewModel);

            repository.AddPhoto(model);
            //return View(viewModel);
            return RedirectToAction("Index");
        }
    }
}
