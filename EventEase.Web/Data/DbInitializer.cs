using EventEase.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace EventEase.Web.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using var context = new EventEaseDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<EventEaseDbContext>>());

            // create databases if they dont exist
            context.Database.EnsureCreated();

            // clear out existing data following foreign key relationships
            context.Bookings.RemoveRange(await context.Bookings.ToListAsync());
            await context.SaveChangesAsync();
            
            context.Events.RemoveRange(await context.Events.ToListAsync());
            await context.SaveChangesAsync();
            
            context.Venues.RemoveRange(await context.Venues.ToListAsync());
            await context.SaveChangesAsync();

            // setup some venue data
            var venues = new Venue[]
            {
                new Venue
                {
                    VenueName = "Grand Ballroom",
                    Location = "123 Main St, Johannesburg",
                    Capacity = 500,
                    ImageUrl = "https://picsum.photos/600/400"
                },
                new Venue
                {
                    VenueName = "Conference Center",
                    Location = "456 Business Ave, Cape Town",
                    Capacity = 300,
                    ImageUrl = "https://picsum.photos/600/400"
                },
                new Venue
                {
                    VenueName = "Garden Pavilion",
                    Location = "789 Park Road, Durban",
                    Capacity = 200,
                    ImageUrl = "https://picsum.photos/600/400"
                }
            };

            await context.Venues.AddRangeAsync(venues);
            await context.SaveChangesAsync();

            // add some events to the system
            var events = new Event[]
            {
                new Event
                {
                    EventName = "Annual Corporate Conference",
                    EventDate = DateTime.Now.AddDays(30),
                    Description = "Annual gathering of corporate partners to discuss business strategies."
                },
                new Event
                {
                    EventName = "Tech Expo 2025",
                    EventDate = DateTime.Now.AddDays(60),
                    Description = "Exhibition showcasing the latest technology innovations."
                },
                new Event
                {
                    EventName = "Wedding Showcase",
                    EventDate = DateTime.Now.AddDays(15),
                    Description = "Showcase of wedding services and venues for potential clients."
                }
            };

            await context.Events.AddRangeAsync(events);
            await context.SaveChangesAsync();

            // seeding the bookings table
            var bookings = new Booking[]
            {
                new Booking
                {
                    EventId = 1,
                    VenueId = 2,
                    BookingDate = DateTime.Now.AddDays(30)
                },
                new Booking
                {
                    EventId = 2,
                    VenueId = 1,
                    BookingDate = DateTime.Now.AddDays(60)
                },
                new Booking
                {
                    EventId = 3,
                    VenueId = 3,
                    BookingDate = DateTime.Now.AddDays(15)
                }
            };

            await context.Bookings.AddRangeAsync(bookings);
            await context.SaveChangesAsync();
        }
    }
} 