using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Techbee.Data;
using Techbee.Model;

namespace Techbee.Pages.TechbeeData
{
    public class DetailsModel : PageModel
    {
        private readonly Techbee.Data.TechbeeContext _context;

        public DetailsModel(Techbee.Data.TechbeeContext context)
        {
            _context = context;
        }

      public TechbeeDetail TechbeeDetail { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TechbeeDetail == null)
            {
                return NotFound();
            }

            var techbeedetail = await _context.TechbeeDetail.FirstOrDefaultAsync(m => m.ID == id);
            if (techbeedetail == null)
            {
                return NotFound();
            }
            else 
            {
                TechbeeDetail = techbeedetail;
            }
            return Page();
        }
    }
}
