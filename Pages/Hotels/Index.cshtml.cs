﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IdealHoliday.Data;
using IdealHoliday.Models;

namespace IdealHoliday.Pages.Hotels
{
    public class IndexModel : PageModel
    {
        private readonly IdealHoliday.Data.IdealHolidayContext _context;

        public IndexModel(IdealHoliday.Data.IdealHolidayContext context)
        {
            _context = context;
        }

        public IList<Hotel> Hotel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Hotel != null)
            {
                Hotel = await _context.Hotel.ToListAsync();
            }
        }
    }
}
