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
        public string DestinationSort { get; set; }
        public string BeginDateSort { get; set; }
        public string CurrentFilter { get; set; }
        public DateTime? CurrentDateFilter { get; set; }
        public async Task OnGetAsync(int? Id, int? categoryId, string sortOrder, string
searchString, DateTime searchDate)

        {
            HolidayD = new HolidayData();

            DestinationSort = String.IsNullOrEmpty(sortOrder) ? "destination_desc" : "destination";
            BeginDateSort = String.IsNullOrEmpty(sortOrder) ? "beginDate_desc" : "beginDate";

            CurrentFilter = searchString;
            CurrentDateFilter = searchDate;


            HolidayD.Holidays = await _context.Holiday
            .Include(b => b.Hotel)
            .Include(b => b.HolidayCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.BeginDate)
            .ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                HolidayD.Holidays = HolidayD.Holidays.Where(s => s.Destination.Contains(searchString)).ToList();
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                HolidayD.Holidays = HolidayD.Holidays.Where(s => s.BeginDate.Date == searchDate.Date).ToList();
            }

                if (Id != null)
            {
                HolidayId = Id.Value;
                Holiday holiday = HolidayD.Holidays
                .Where(i => i.Id == Id.Value).Single();
                HolidayD.Categories = holiday.HolidayCategories.Select(s => s.Category);
            }
            switch (sortOrder)
            {
                case "destination_desc":
                    HolidayD.Holidays = HolidayD.Holidays.OrderByDescending(s =>
                   s.Destination);
                    break;
                case "beginDate_desc":
                    HolidayD.Holidays = HolidayD.Holidays.OrderByDescending(s => s.BeginDate);
                    break;
                case "destination":
                    HolidayD.Holidays = HolidayD.Holidays.OrderBy(s => s.Destination);
                    break;
                case "beginDate":
                    HolidayD.Holidays = HolidayD.Holidays.OrderBy(s => s.BeginDate);
                    break;
                default:
                    HolidayD.Holidays = HolidayD.Holidays.OrderBy(s => s.Destination);
                    break;

            }
        }
    }
}
