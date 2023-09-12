using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace ASP_Test_01.Model
{
    public class Book
    {

        private static int nextId = 1;

        public Book()
        {
           Id = nextId;
            nextId++;
        }
        public int Id { get; }

        [MinLength(3)]
        [MaxLength(50)]
        [Required]
        public string Title { get; set; }
        [MinLength(3)]
        [MaxLength(50)]
        [Required]
        public string Author { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public double ISBN { get; set;}


    }
}
