using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EventEase.Web.Models;
using EventEase.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace EventEase.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly EventEaseDbContext _context;

    public HomeController(ILogger<HomeController> logger, EventEaseDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var viewModel = new DashboardViewModel
        {
            VenueCount = await _context.Venues.CountAsync(),
            EventCount = await _context.Events.CountAsync(),
            BookingCount = await _context.Bookings.CountAsync(),
            RecentBookings = await _context.Bookings
                .Include(b => b.Event)
                .Include(b => b.Venue)
                .OrderByDescending(b => b.BookingDate)
                .Take(5)
                .ToListAsync()
        };

        return View(viewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
