using FamilyPhotos.ViewModel.Validators;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyPhotos.ViewModel
{
    public class PhotoViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Ez pedig csak a browserből történő file feltöltésre szolgál
        /// </summary>
        /// 
        [Required]
        [ImageMimeTypeValidation]
        public IFormFile PictureFromBrowser { get; set; }
    }
}
