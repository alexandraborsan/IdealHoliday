using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using IdealHoliday.Data;
using IdealHoliday.Models;
using Microsoft.AspNetCore.Authorization;

namespace IdealHoliday.Pages.Hotels
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly IdealHoliday.Data.IdealHolidayContext _context;

        public CreateModel(IdealHoliday.Data.IdealHolidayContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Hotel Hotel { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Hotel == null || Hotel == null)
            {
                return Page();
            }

            _context.Hotel.Add(Hotel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
