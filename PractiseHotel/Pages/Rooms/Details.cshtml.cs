using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PractiseHotel.Data;
using PractiseHotel.Models;

namespace PractiseHotel.Pages.Rooms
{
    public class DetailsModel : PageModel
    {
        private readonly PractiseHotel.Data.PractiseHotelContext _context;

        public DetailsModel(PractiseHotel.Data.PractiseHotelContext context)
        {
            _context = context;
        }

        public RoomModel RoomModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roommodel = await _context.RoomModel.FirstOrDefaultAsync(m => m.Id == id);
            if (roommodel == null)
            {
                return NotFound();
            }
            else
            {
                RoomModel = roommodel;
            }
            return Page();
        }
    }
}
