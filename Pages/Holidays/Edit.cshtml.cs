using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IdealHoliday.Data;
using IdealHoliday.Models;
using System.Security.Policy;
using Microsoft.AspNetCore.Authorization;

namespace IdealHoliday.Pages.Holidays
{
    [Authorize(Roles = "Admin")]

    public class EditModel : HolidayCategoriesPageModel
    {
        private readonly IdealHoliday.Data.IdealHolidayContext _context;

        public EditModel(IdealHoliday.Data.IdealHolidayContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Holiday Holiday { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            Holiday =  await _context.Holiday
                .Include(b => b.Hotel)
                .Include(b => b.HolidayCategories).ThenInclude(b => b.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == Id);

            if (Holiday == null)
            {
                return NotFound();
            }

            PopulateAssignedCategoryData(_context, Holiday); 
            Holiday = Holiday;
            ViewData["HotelId"] = new SelectList(_context.Set<Hotel>(), "Id",
"HotelName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? Id, string[] selectedCategories)
        {
            if (Id == null)
            {
                return NotFound();
            }
           
            var holidayToUpdate = await _context.Holiday
            .Include(i => i.Hotel)
            .Include(i => i.HolidayCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.Id == Id);
            if (holidayToUpdate == null)
            {
                return NotFound();
            }
           
            if (await TryUpdateModelAsync<Holiday>(
            holidayToUpdate,
            "Holiday",
            i => i.Destination, i => i.BeginDate,
            i => i.EndDate, i => i.NumberOfAdults, i => i.NumberOfKids,
            i => i.Price, i => i.HotelId))
            {
                UpdateHolidayCategories(_context, selectedCategories, holidayToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateHolidayCategories(_context, selectedCategories, holidayToUpdate);
            PopulateAssignedCategoryData(_context, holidayToUpdate);
            return Page();
        }
    }
}
