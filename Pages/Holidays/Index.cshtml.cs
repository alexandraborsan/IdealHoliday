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
    public class IndexModel : PageModel
    {
        private readonly IdealHoliday.Data.IdealHolidayContext _context;

        public IndexModel(IdealHoliday.Data.IdealHolidayContext context)
        {
            _context = context;
        }

        public IList<Holiday> Holiday { get; set; }

        public HolidayData HolidayD { get; set; }
        public int HolidayId { get; set; }
        public int CategoryId { get; set; }
        public async Task OnGetAsync(int? Id, int? categoryId)
        {
            HolidayD = new HolidayData();

            HolidayD.Holidays = await _context.Holiday
            .Include(b => b.Hotel)
            .Include(b => b.HolidayCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.BeginDate)
            .ToListAsync();
            if (Id != null)
            {
                HolidayId = Id.Value;
                Holiday holiday = HolidayD.Holidays
                .Where(i => i.Id == Id.Value).Single();
                HolidayD.Categories = holiday.HolidayCategories.Select(s => s.Category);
            }
        }
    }
}
