using Microsoft.EntityFrameworkCore;
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
                return db.Pizzas.Where(x => x.Id == id).Include(p => p.Category).FirstOrDefault();
            return db.Pizzas.FirstOrDefault(p => p.Id == id);
        }

        public static List<Category> GetAllCategories()
        {
            using PizzaContext db = new PizzaContext();
            return db.Categories.ToList();
        }

        public static void InsertPizza(Pizza pizza)
        {
            using PizzaContext db = new PizzaContext();
            db.Pizzas.Add(pizza);
            db.SaveChanges();
        }

        public static bool UpdatePizza(int id, Pizza pizza)
        {
            try
            {
                // Non posso riusare GetPizza()
                // perché il DbContext deve continuare a vivere
                // affinché possa accorgersi di quali modifiche deve salvare
                using PizzaContext db = new PizzaContext();
                var pizzaDaModificare = db.Pizzas.FirstOrDefault(p => p.Id == id);
                if (pizzaDaModificare == null)
                    return false;
                pizzaDaModificare.Name = pizza.Name;
                pizzaDaModificare.Description = pizza.Description;
                pizzaDaModificare.Price = pizza.Price;
                pizzaDaModificare.CategoryId = pizza.CategoryId;

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
                PizzaManager.InsertPizza(new Pizza("Margherita", "La pizza altezzosa", 5.5M));
                PizzaManager.InsertPizza(new Pizza("Diavola", "La pizza arrabbiosa", 7M));
                PizzaManager.InsertPizza(new Pizza("Marinara", "La pizza sabbiosa", 6.5M));
            }
        }
    }
}
