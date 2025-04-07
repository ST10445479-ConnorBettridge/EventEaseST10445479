using System.ComponentModel.DataAnnotations;

namespace EventEase.Web.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [Required]
        [StringLength(100)]
        public string EventName { get; set; } = string.Empty;

        [Required]
        public DateTime EventDate { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        // link to bookings
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}