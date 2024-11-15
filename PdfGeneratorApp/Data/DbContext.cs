using Microsoft.EntityFrameworkCore;
using PdfGeneratorApp.Models;


namespace PdfGeneratorApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=your_database_name;Username=your_username;Password=your_password");
        }
    }
}
