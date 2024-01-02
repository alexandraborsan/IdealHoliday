using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using IdealHoliday.Data;
using IdealHoliday.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace IdealHoliday.Pages.Bookings
{ 

    public class CreateModel : PageModel
    {
        private readonly IdealHoliday.Data.IdealHolidayContext _context;

        public CreateModel(IdealHoliday.Data.IdealHolidayContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var holidayList = _context.Holiday
                .Include(h => h.Customer)
                .Select(x => new
                {
                    x.Id,
                    HolidayFullName = x.Destination + x.Customer.LastName + " " +
                                      x.Customer.FirstName
                });

            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "HolidayFullName");
            ViewData["HolidayId"] = new SelectList(holidayList, "Id", "HolidayFullName");

            return Page();
        }

        [BindProperty]
        public Booking Booking { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Booking == null || Booking == null)
            {
                return Page();
            }

            _context.Booking.Add(Booking);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
