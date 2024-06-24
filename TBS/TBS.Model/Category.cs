using System.ComponentModel.DataAnnotations;

namespace TBS.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }
    }
}
