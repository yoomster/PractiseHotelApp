using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PractiseHotel.Data;
using PractiseHotel.Models;

namespace PractiseHotel.Pages.Rooms
{
    public class EditModel : PageModel
    {
        private readonly PractiseHotel.Data.PractiseHotelContext _context;

        public EditModel(PractiseHotel.Data.PractiseHotelContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RoomModel RoomModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roommodel =  await _context.RoomModel.FirstOrDefaultAsync(m => m.Id == id);
            if (roommodel == null)
            {
                return NotFound();
            }
            RoomModel = roommodel;
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

            _context.Attach(RoomModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomModelExists(RoomModel.Id))
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

        private bool RoomModelExists(int id)
        {
            return _context.RoomModel.Any(e => e.Id == id);
        }
    }
}
