using KindHands.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KindHands.DAL.Data
{
    public class KindHandsDbContext : DbContext
    {
        public DbSet<Ad> Ads { get; set; }
        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<VolunteerAd> VolunteerAds { get; set; }

        public KindHandsDbContext(DbContextOptions<KindHandsDbContext> options) : base(options)
        {
            // Empty constructor body as it just calls the base class constructor
        }
    }
}