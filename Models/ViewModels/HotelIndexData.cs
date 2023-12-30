using System.Security.Policy;
using IdealHoliday.Models;


namespace IdealHoliday.Models.ViewModels
{
    public class HotelIndexData
    {
        public IEnumerable<Hotel> Hotels { get; set; }
        public IEnumerable<Holiday> Holidays { get; set; }
    }
}
