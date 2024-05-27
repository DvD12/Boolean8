using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PizzaMvc.Models;

namespace PizzaMvc.Data
{
    public enum ResultType
    {
        OK,
        Exception,
        NotFound
    }

    public static class PizzaManager
    {
        public static int CountAllPizzas()
        {
            using PizzaContext db = new PizzaContext();
            return db.Pizzas.Count();
        }

        public static List<Pizza> GetAllPizzas()
        {
            using PizzaContext db = new PizzaContext();
            return db.Pizzas.ToList();
        }

        public static Pizza GetPizza(int id, bool includeReferences = true)
        {
            using PizzaContext db = new PizzaContext();
            if (includeReferences)
                return db.Pizzas.Where(x => x.Id == id).Include(p => p.Category).Include(p => p.Ingredients).FirstOrDefault();
            return db.Pizzas.FirstOrDefault(p => p.Id == id);
        }

        public static Pizza GetPizzaByName(string name)
        {
            using PizzaContext db = new PizzaContext();
            return db.Pizzas.FirstOrDefault(p => p.Name == name);
        }

        public static List<Pizza> GetPizzasByName(string name)
        {
            using PizzaContext db = new PizzaContext();

            // Rendo la ricerca case-insensitive convertendo tutto in minuscole
            return db.Pizzas.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList();
        }

        public static List<Category> GetAllCategories()
        {
            using PizzaContext db = new PizzaContext();
            return db.Categories.ToList();
        }
        public static List<Ingredient> GetAllIngredients()
        {
            using PizzaContext db = new PizzaContext();
            return db.Ingredients.ToList();
        }


        public static void InsertPizza(Pizza pizza, List<string> selectedIngredients)
        {
            using PizzaContext db = new PizzaContext();
            pizza.Ingredients = new List<Ingredient>();
            if (selectedIngredients != null)
            {
                // Trasformiamo gli ID scelti in ingredienti da aggiungere tra i riferimenti in Pizza
                foreach (var ingredient in selectedIngredients)
                {
                    int id = int.Parse(ingredient);
                    // NON usiamo un GetIngredientById() perché userebbe un db context diverso
                    // e ciò causerebbe errore in fase di salvataggio - usiamo lo stesso context all'interno della stessa operazione
                    var ingredientFromDb = db.Ingredients.FirstOrDefault(x => x.Id == id);
                    if (ingredientFromDb != null)
                    {
                        pizza.Ingredients.Add(ingredientFromDb);
                    }
                }
            }
            db.Pizzas.Add(pizza);
            db.SaveChanges();
        }

        public static bool UpdatePizza(int id, Pizza pizza, List<string> selectedIngredients)
        {
            try
            {
                // Non posso riusare GetPizza()
                // perché il DbContext deve continuare a vivere
                // affinché possa accorgersi di quali modifiche deve salvare
                using PizzaContext db = new PizzaContext();
                var pizzaDaModificare = db.Pizzas.Where(p => p.Id == id).Include(p => p.Ingredients).FirstOrDefault();
                if (pizzaDaModificare == null)
                    return false;
                pizzaDaModificare.Name = pizza.Name;
                pizzaDaModificare.Description = pizza.Description;
                pizzaDaModificare.Price = pizza.Price;
                pizzaDaModificare.CategoryId = pizza.CategoryId;

                // Prima svuoto così da salvare solo le informazioni che l'utente ha scelto, NON le aggiungiamo ai vecchi dati
                pizzaDaModificare.Ingredients.Clear();
                if (selectedIngredients != null)
                {
                    foreach (var ingredient in selectedIngredients)
                    {
                        int ingredientId = int.Parse(ingredient);
                        var ingredientFromDb = db.Ingredients.FirstOrDefault(x => x.Id == ingredientId);
                        if (ingredientFromDb != null)
                            pizzaDaModificare.Ingredients.Add(ingredientFromDb);
                    }
                }

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static ResultType UpdatePizzaWithEnum(int id, Pizza pizza) // solo a scopo didattico
        {
            try
            {
                using PizzaContext db = new PizzaContext();
                var pizzaDaModificare = db.Pizzas.FirstOrDefault(p => p.Id == id);
                if (pizzaDaModificare == null)
                    return ResultType.NotFound;
                pizzaDaModificare.Name = pizza.Name;
                pizzaDaModificare.Description = pizza.Description;
                pizzaDaModificare.Price = pizza.Price;

                db.SaveChanges();
                return ResultType.OK;
            }
            catch (Exception ex)
            {
                return ResultType.Exception;
            }
        }

        public static bool DeletePizza(int id)
        {
            try
            {
                //using PizzaContext db = new PizzaContext();
                var pizzaDaCancellare = GetPizza(id, false); // db.Pizzas.FirstOrDefault(p => p.Id == id);
                if (pizzaDaCancellare == null)
                    return false;

                using PizzaContext db = new PizzaContext();
                db.Remove(pizzaDaCancellare);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static void Seed()
        {
            if (PizzaManager.CountAllPizzas() == 0)
            {
                PizzaManager.InsertPizza(new Pizza("Margherita", "La pizza altezzosa", 5.5M), new());
                PizzaManager.InsertPizza(new Pizza("Diavola", "La pizza arrabbiosa", 7M), new());
                PizzaManager.InsertPizza(new Pizza("Marinara", "La pizza sabbiosa", 6.5M), new());
            }
        }
    }
}
