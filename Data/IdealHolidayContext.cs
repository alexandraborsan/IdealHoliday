using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IdealHoliday.Models;

namespace IdealHoliday.Data
{
    public class IdealHolidayContext : DbContext
    {
        public IdealHolidayContext (DbContextOptions<IdealHolidayContext> options)
            : base(options)
        {
        }

        public DbSet<IdealHoliday.Models.Holiday> Holiday { get; set; } = default!;

        public DbSet<IdealHoliday.Models.Hotel>? Hotel { get; set; }

        public DbSet<IdealHoliday.Models.Category>? Category { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Holiday>()
                .HasOne(h => h.Booking)
                .WithOne(b => b.Holiday)
                .HasForeignKey<Booking>(b => b.HolidayId);
        }
        public DbSet<IdealHoliday.Models.Customer>? Customer { get; set; }
        public DbSet<IdealHoliday.Models.Booking>? Booking { get; set; }
    }
}
