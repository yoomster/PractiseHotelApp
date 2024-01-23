using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PractiseHotel.Models;

namespace PractiseHotel.Data
{
    public class PractiseHotelContext : DbContext
    {
        public PractiseHotelContext (DbContextOptions<PractiseHotelContext> options)
            : base(options)
        {
        }

        public DbSet<PractiseHotel.Models.RoomModel> RoomModel { get; set; } = default!;
    }
}
