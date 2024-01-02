using System.ComponentModel.DataAnnotations;

namespace IdealHoliday.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public int? HolidayId { get; set; }
        public Holiday? Holiday { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Reservation Date")]
        public DateTime? ReservationDate { get; set; }
    }
}
