using System.ComponentModel.DataAnnotations;

namespace IdealHoliday.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        [Display(Name = "Hotel")]
        public string? HotelName { get; set; }
        [Display(Name = "Number of Stars")]
        public int NumberOfStars { get; set; }
       
    }
}
