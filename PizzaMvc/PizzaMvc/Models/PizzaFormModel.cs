namespace PizzaMvc.Models
{
    public class PizzaFormModel
    {
        public List<Category>? Categories { get; set; }
        public Pizza Pizza { get; set; }

        public PizzaFormModel() { }

        public PizzaFormModel(Pizza pizza, List<Category>? categories)
        {
            Pizza = pizza;
            Categories = categories;
        }
    }
}
