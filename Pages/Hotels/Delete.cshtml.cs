using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IdealHoliday.Data;
using IdealHoliday.Models;

namespace IdealHoliday.Pages.Hotels
{
    public class DeleteModel : PageModel
    {
        private readonly IdealHoliday.Data.IdealHolidayContext _context;

        public DeleteModel(IdealHoliday.Data.IdealHolidayContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Hotel Hotel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Hotel == null)
            {
                return NotFound();
            }

            var hotel = await _context.Hotel.FirstOrDefaultAsync(m => m.Id == id);

            if (hotel == null)
            {
                return NotFound();
            }
            else 
            {
                Hotel = hotel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Hotel == null)
            {
                return NotFound();
            }
            var hotel = await _context.Hotel.FindAsync(id);

            if (hotel != null)
            {
                Hotel = hotel;
                _context.Hotel.Remove(Hotel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
