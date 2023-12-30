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
    }
}
