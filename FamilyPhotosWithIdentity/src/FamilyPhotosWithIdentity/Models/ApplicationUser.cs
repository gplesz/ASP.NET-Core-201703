using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FamilyPhotosWithIdentity.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// Amelyik felhasználónál beállítjuk, ott engedélyezzük a 
        /// a felhasználók menedzselését
        /// </summary>
        public bool IsAdmin { get; set; }
    }
}
