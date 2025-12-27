using MelodyTrack.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MelodyTrack.API.Data
{
    public class MelodyDbContext : DbContext
    {
        public MelodyDbContext(DbContextOptions<MelodyDbContext> options) : base(options) { }

        public DbSet<Repertoire> Repertoires { get; set; }
        public DbSet<Grade> Grades { get; set; }
    }
}