using System.ComponentModel.DataAnnotations;

namespace IdealHoliday.Models
{
    public class HolidayCategory
    {
        public int Id { get; set; }
        public int HolidayID { get; set; }
        public Holiday? Holiday { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
