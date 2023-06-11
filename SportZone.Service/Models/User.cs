using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SportZone.Service.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Ad")]
        [Required(ErrorMessage = "Bu alan zorunludur")]
        public string Name { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = "Bu alan zorunludur")]
        public string Email { get; set; }
        [DisplayName("Şifre")]
        [Required(ErrorMessage = "Bu alan zorunludur")]
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }
}