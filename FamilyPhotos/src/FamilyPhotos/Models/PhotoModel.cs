using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
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

        public string Title { get; set; }

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
