using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportZone.Service.Models
{
    public class Sport
    {
        [Key]
        public int Id { get; set; }

        //[ForeignKey("Category")]
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public Category Category { get; set; }

    }
}
