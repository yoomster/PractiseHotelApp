using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PractiseHotel.Data;
using PractiseHotel.Models;

namespace PractiseHotel.Pages.Rooms
{
    public class CreateModel : PageModel
    {
        private readonly PractiseHotel.Data.PractiseHotelContext _context;

        public CreateModel(PractiseHotel.Data.PractiseHotelContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public RoomModel RoomModel { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.RoomModel.Add(RoomModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
