using System.ComponentModel.DataAnnotations;

namespace IdealHoliday.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Display(Name = "Category")]
        public string? CategoryName { get; set; }
        public ICollection<HolidayCategory>? HolidayCategories { get; set; }
    }
}
