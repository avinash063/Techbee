using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Techbee.Data;
using Techbee.Model;

namespace Techbee.Pages.TechbeeData
{
    public class EditModel : PageModel
    {
        private readonly Techbee.Data.TechbeeContext _context;

        public EditModel(Techbee.Data.TechbeeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TechbeeDetail TechbeeDetail { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TechbeeDetail == null)
            {
                return NotFound();
            }

            var techbeedetail =  await _context.TechbeeDetail.FirstOrDefaultAsync(m => m.ID == id);
            if (techbeedetail == null)
            {
                return NotFound();
            }
            TechbeeDetail = techbeedetail;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TechbeeDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TechbeeDetailExists(TechbeeDetail.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TechbeeDetailExists(int id)
        {
          return (_context.TechbeeDetail?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
