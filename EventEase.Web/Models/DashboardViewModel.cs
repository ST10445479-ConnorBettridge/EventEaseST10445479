namespace EventEase.Web.Models
{
    public class DashboardViewModel
    {
        public int VenueCount { get; set; }
        public int EventCount { get; set; }
        public int BookingCount { get; set; }
        public IEnumerable<Booking> RecentBookings { get; set; } = new List<Booking>();
    }
} 