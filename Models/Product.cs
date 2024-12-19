using System.ComponentModel.DataAnnotations;


namespace ProductManagementApp.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string? ImagePath { get; set; }
    }

}
