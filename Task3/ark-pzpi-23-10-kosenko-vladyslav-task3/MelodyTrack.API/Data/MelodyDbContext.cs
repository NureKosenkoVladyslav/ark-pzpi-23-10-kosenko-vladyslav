using MelodyTrack.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MelodyTrack.API.Data
{
    public class MelodyDbContext : DbContext
    {
        public MelodyDbContext(DbContextOptions<MelodyDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; } 
        public DbSet<Repertoire> Repertoire { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Subject> Subjects { get; set; }
    }
}