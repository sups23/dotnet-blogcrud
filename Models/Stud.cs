using System.ComponentModel.DataAnnotations;

namespace BlogCrud.Models
{
    public class Stud
    {
        public int ID { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public int? Age { get; set; }
        public string? Address { get; set; }

    }
}