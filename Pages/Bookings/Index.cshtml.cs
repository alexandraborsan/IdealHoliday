using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IdealHoliday.Data;
using IdealHoliday.Models;

namespace IdealHoliday.Pages.Bookings
{
    public class IndexModel : PageModel
    {
        private readonly IdealHoliday.Data.IdealHolidayContext _context;

        public IndexModel(IdealHoliday.Data.IdealHolidayContext context)
        {
            _context = context;
        }

        public IList<Booking> Booking { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Booking != null)
            {
                Booking = await _context.Booking
                .Include(b => b.Customer)
                .Include(b => b.Holiday).ToListAsync();
            }
        }
    }
}
