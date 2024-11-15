using Microsoft.EntityFrameworkCore;
using PdfGeneratorApp.Data;
using PdfGeneratorApp.Models;

namespace PdfGenerator.Services
{
    public class DataLoaderService
    {
        public async Task<List<Person>> LoadPeopleAsync()
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    return await context.People.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке данных: {ex.Message}");
                return new List<Person>();
            }
        }
    }
}
