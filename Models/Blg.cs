using System.ComponentModel.DataAnnotations;

namespace BlogCrud.Models
{
    public class Blg
    {
        public int ID { get; set; }
        [Required]
        public string? Author { get; set; }
        [Required]
        public string? Title { get; set; }
        public string? Text { get; set; }

    }
}