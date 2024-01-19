using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WebProje1.Models
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options)
        {


        }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
