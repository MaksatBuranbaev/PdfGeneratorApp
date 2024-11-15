using System.ComponentModel.DataAnnotations;

namespace PdfGeneratorApp.Models
{
    public class Person
    {
        [Key]
        public int Number { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
    }
}
