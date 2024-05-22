using System.ComponentModel.DataAnnotations;

namespace PizzaMvc.Models
{
    public class Ingredient
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }

        public List<Pizza> Pizzas { get; set; }
    }
}
