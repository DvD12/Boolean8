using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaMvc.Data;

namespace PizzaMvc.Models
{
    public class PizzaFormModel
    {
        public List<Category>? Categories { get; set; }
        public Pizza Pizza { get; set; }
        public List<SelectListItem>? Ingredients { get; set; } // Gli elementi degli ingredienti selezionabili per la select (analogo a Categories)
        public List<string>? SelectedIngredients { get; set; } // Gli ID degli elementi effettivamente selezionati

        public PizzaFormModel() { }

        public PizzaFormModel(Pizza pizza, List<Category>? categories)
        {
            Pizza = pizza;
            Categories = categories;
            SelectedIngredients = new List<string>();
            if (Pizza.Ingredients != null)
                foreach (var i in Pizza.Ingredients)
                    SelectedIngredients.Add(i.Id.ToString());
        }

        public void CreateIngredients()
        {
            this.Ingredients = new List<SelectListItem>();
            if (this.SelectedIngredients == null)
                this.SelectedIngredients = new List<string>();
            var ingredientsFromDB = PizzaManager.GetAllIngredients();
            foreach (var ingrendient in ingredientsFromDB) // tutti gli ingredienti possibili: i1, i2, i3, ... i10
            {
                bool isSelected = this.SelectedIngredients.Contains(ingrendient.Id.ToString()); // this.Pizza.Ingredients?.Any(i => i.Id == ingrendient.Id) == true;
                this.Ingredients.Add(new SelectListItem() // lista degli elementi selezionabili
                {
                    Text = ingrendient.Name, // Testo visualizzato
                    Value = ingrendient.Id.ToString(), // SelectListItem vuole una generica stringa, non un int
                    Selected = isSelected // es. i1, i5, i9
                });
                //if (isSelected)
                //    this.SelectedIngredients.Add(ingrendient.Id.ToString()); // lista degli elementi selezionati
            }
        }
    }
}
