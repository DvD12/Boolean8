using System.ComponentModel.DataAnnotations;

namespace PizzaMvc.Data
{
    public class Pizza
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string? Image { get; set; }

        public Pizza() { }

        public Pizza(string name, string description, decimal price)
        {
            this.Name = name;
            this.Description = description;
            this.Price = price;
        }
    }
}
