using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyPhotos.ViewModel.Validators
{
    public class ImageMimeTypeValidationAttribute : ValidationAttribute
    {
        public List<string> EnabledMimeType { get; set; }

        public ImageMimeTypeValidationAttribute() 
            : this(
                  new List<string> { "image/jpeg", "image/png" }, 
                  "Nem megfelelő képformátum: {0}. Ezekből lehet választani: {0}")
        { }

        public ImageMimeTypeValidationAttribute(List<string> enabledMimeType, string errorMessage)
        {
            EnabledMimeType = enabledMimeType;
            ErrorMessage = errorMessage;
        }

        public override bool IsValid(object value)
        {
            var file = value as IFormFile;
            if (file==null)
            {
                return false;
            }
            return EnabledMimeType.Contains(file.ContentType);
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessage, name, string.Join(",", EnabledMimeType));
        }

    }
}
