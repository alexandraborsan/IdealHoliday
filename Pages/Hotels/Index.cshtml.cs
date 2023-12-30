using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IdealHoliday.Data;
using IdealHoliday.Models;
using IdealHoliday.Models.ViewModels;

namespace IdealHoliday.Pages.Hotels
{
    public class IndexModel : PageModel
    {
        private readonly IdealHoliday.Data.IdealHolidayContext _context;

        public IndexModel(IdealHoliday.Data.IdealHolidayContext context)
        {
            _context = context;
        }

        public IList<Hotel> Hotel { get; set; } = default!;

        public HotelIndexData HotelData { get; set; }
        public int HotelId { get; set; }
        public int HolidayId { get; set; }
        public async Task OnGetAsync(int? Id, int? holidayId)
        {
            HotelData = new HotelIndexData();
            HotelData.Hotels = await _context.Hotel
            .Include(i => i.Holidays)
            .OrderBy(i => i.HotelName)
            .ToListAsync();
            if (Id != null)
            {
                HotelId = Id.Value;
                Hotel hotel = HotelData.Hotels
                .Where(i => i.Id == Id.Value).Single();
                HotelData.Holidays = hotel.Holidays;
            }
        }
    }



}
