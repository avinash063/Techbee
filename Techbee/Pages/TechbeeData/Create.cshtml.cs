using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Techbee.Data;
using Techbee.Model;

namespace Techbee.Pages.TechbeeData
{
    public class CreateModel : PageModel
    {
        private readonly Techbee.Data.TechbeeContext _context;

        public CreateModel(Techbee.Data.TechbeeContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TechbeeDetail TechbeeDetail { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.TechbeeDetail == null || TechbeeDetail == null)
            {
                return Page();
            }

            _context.TechbeeDetail.Add(TechbeeDetail);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
