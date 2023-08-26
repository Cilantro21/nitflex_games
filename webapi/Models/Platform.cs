using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class Platform
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public string? Manufacturer { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime EndOfSupport { get; set; }

        public ICollection<Game>? Games { get; set; }
    }
}
