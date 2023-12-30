using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace IdealHoliday.Models
{
    public class Holiday
    {
        public int Id { get; set; }
        public string? Destination { get; set; }

        [Display(Name = "Begining Date")]
        [DataType(DataType.Date)]
        public DateTime BeginDate { get; set; }
        [Display(Name = "Ending Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [Display(Name = "Number of adults")]
        public int NumberOfAdults { get; set; }
        [Display(Name = "Number of children")]
        public int? NumberOfKids { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        [Range(0.01, 50000)]
        public decimal Price { get; set; }
        public int? HotelId { get; set; }
        public Hotel? Hotel { get; set; }
        
        public int? BookingId { get; set; }
        public Booking? Booking { get; set; }
    
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public ICollection<HolidayCategory>? HolidayCategories { get; set; }
    }

}
