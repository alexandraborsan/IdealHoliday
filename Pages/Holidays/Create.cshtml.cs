using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using IdealHoliday.Data;
using IdealHoliday.Models;
using System.Security.Policy;

namespace IdealHoliday.Pages.Holidays
{
    public class CreateModel : HolidayCategoriesPageModel
    {
        private readonly IdealHoliday.Data.IdealHolidayContext _context;

        public CreateModel(IdealHoliday.Data.IdealHolidayContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["HotelId"] = new SelectList(_context.Set<Hotel>(), "Id",
"HotelName");
            var holiday = new Holiday();
            holiday.HolidayCategories = new List<HolidayCategory>();
            PopulateAssignedCategoryData(_context, holiday);

            return Page();
        }

        [BindProperty]
        public Holiday Holiday { get; set; } = default!;
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newHoliday = new Holiday();
            if (selectedCategories != null)
            {
                newHoliday.HolidayCategories = new List<HolidayCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new HolidayCategory
                    {
                        CategoryId = int.Parse(cat)
                    };
                    newHoliday.HolidayCategories.Add(catToAdd);
                }
            }
            Holiday.HolidayCategories = newHoliday.HolidayCategories;
            _context.Holiday.Add(Holiday);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Holiday == null || Holiday == null)
            {
                return Page();
            }

            _context.Holiday.Add(Holiday);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
