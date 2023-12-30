namespace IdealHoliday.Models
{
    public class HolidayData
    {
        public IEnumerable<Holiday> Holidays { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<HolidayCategory> HolidayCategories { get; set; }
    }
}
