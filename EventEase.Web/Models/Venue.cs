using System.ComponentModel.DataAnnotations;

namespace EventEase.Web.Models
{
    public class Venue
    {
        [Key]
        public int VenueId { get; set; }

        [Required]
        [StringLength(100)]
        public string VenueName { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string Location { get; set; } = string.Empty;

        [Required]
        public int Capacity { get; set; }

        public string? ImageUrl { get; set; }

        // venue bookings list
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}