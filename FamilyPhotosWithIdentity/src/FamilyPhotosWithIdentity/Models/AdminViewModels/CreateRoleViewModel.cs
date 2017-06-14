using System.ComponentModel.DataAnnotations;

namespace FamilyPhotosWithIdentity.Models.AdminViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}