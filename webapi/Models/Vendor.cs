using System.ComponentModel.DataAnnotations;

namespace webapi.Models
{
    public class Vendor
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Country { get; set; }

        public DateTime Foundation { get; set; }

        public string? About { get; set; }

        public ICollection<Game>? Games { get; set; }
    }
}
