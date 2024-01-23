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
    public class IndexModel : PageModel
    {
        private readonly PractiseHotel.Data.PractiseHotelContext _context;

        public IndexModel(PractiseHotel.Data.PractiseHotelContext context)
        {
            _context = context;
        }

        public IList<RoomModel> RoomModel { get;set; } = default!;

        public async Task OnGetAsync()
        {
            RoomModel = await _context.RoomModel.ToListAsync();
        }
    }
}
