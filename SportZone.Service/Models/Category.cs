using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SportZone.Service.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Ad")]
        [Required(ErrorMessage = "Bu alan zorunludur")]
        public string Name { get; set; }
        public virtual ICollection<Sport> Sports { get; set; }

    }
}
