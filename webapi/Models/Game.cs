﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Models
{
    public class Game
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        [Range(0, 10)]
        public double Score { get; set; }

        public int PlatformId { get; set; }
        [ForeignKey("PlatformId")]
        public Platform? Platform { get; set; }

        public int VendorId { get; set; }
        [ForeignKey("VendorId")]
        public Vendor? Vendor { get; set; }

    }
}
