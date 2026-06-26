using Microsoft.EntityFrameworkCore;
using NoteApp.Models;

namespace NoteApp.Data {
    public class DBContext : DbContext{

        // Add Tables
        public DbSet<Note> Notes { get; set; }

        // Connection
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "AppDBNote.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }
}
