using System.ComponentModel.DataAnnotations;

namespace PizzaMvc.Models
{
    public class Pizza
    {
        [Key] public int Id { get; set; }
        [Required(ErrorMessage = "Il campo è richiesto")]
        [StringLength(40, ErrorMessage = " Il campo deve contenere max 40 caratteri")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Il campo è richiesto")]
        [StringLength(200, ErrorMessage = " Il campo deve contenere max 200 caratteri")]
        [MinWords(5)]
        public string Description { get; set; }
        [Range(0.01, 10000, ErrorMessage = "Il valore deve essere maggiore di 0")]
        public decimal Price { get; set; }
        public string? Image { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public List<Ingredient>? Ingredients { get; set; }

        public Pizza() { }

        public Pizza(string name, string description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
        }

        public string GetDisplayedCategory()
        {
            if (Category == null)
                return "Nessuna categoria";
            return Category.Name;
        }
    }
}
