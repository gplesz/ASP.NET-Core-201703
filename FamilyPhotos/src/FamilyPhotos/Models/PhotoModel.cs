using FamilyPhotos.ViewModel.Validation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyPhotos.Models
{
    public class PhotoModel
    {
        public PhotoModel()
        {
            CreatedDate = DateTime.Today;
            ModifiedDate = DateTime.Today;

        }

        public int Id { get; set; }

        /// <summary>
        /// Beépített validációk (Data Validation)
        /// 
        /// Required
        /// StringLength
        /// 
        /// + saját validálás készítése
        /// </summary>

        [Required] //Kötelező kitölteni a mezőt
        [StringLength(40)]
        public string Title { get; set; }

        [Required] //Kötelező kitölteni a mezőt
        public string Description { get; set; }

        /// <summary>
        /// Ezt fogjuk majd adatbázisba menteni
        /// </summary>
        public byte[] Picture { get; set; }

        public string ContentType { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
