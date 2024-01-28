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
    public class IndexModel : PageModel
    {
        private readonly Techbee.Data.TechbeeContext _context;

        public IndexModel(Techbee.Data.TechbeeContext context)
        {
            _context = context;
        }

        public IList<TechbeeDetail> TechbeeDetail { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.TechbeeDetail != null)
            {
                TechbeeDetail = await _context.TechbeeDetail.ToListAsync();
            }
        }
    }
}
