using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IdealHoliday.Data;
using IdealHoliday.Models;

namespace IdealHoliday.Pages.Holidays
{
    public class DetailsModel : PageModel
    {
        private readonly IdealHoliday.Data.IdealHolidayContext _context;

        public DetailsModel(IdealHoliday.Data.IdealHolidayContext context)
        {
            _context = context;
        }

      public Holiday Holiday { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Holiday == null)
            {
                return NotFound();
            }

            var holiday = await _context.Holiday.FirstOrDefaultAsync(m => m.Id == id);
            if (holiday == null)
            {
                return NotFound();
            }
            else 
            {
                Holiday = holiday;
            }
            return Page();
        }
    }
}
