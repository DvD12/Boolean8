using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio016_EF
{
    public static class VideogameManager
    {
        public static void InserisciVideogame(Videogame v)
        {
            using VideogameContext db = new VideogameContext();
            db.Add(v);
            db.SaveChanges();
        }

        public static Videogame GetVideogameById(long id)
        {
            try
            {
                using VideogameContext db = new VideogameContext();
                return db.Videogames.Where(x => x.Id == id).Include(x => x.SoftwareHouse).FirstOrDefault(); // Può ritornare il videogame oppure null
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static List<Videogame> GetVideogamesByName(string name)
        {
            using VideogameContext db = new VideogameContext();
            return db.Videogames.Where(x => x.Name.Contains(name)).ToList();
        }

        public static void DeleteVideogameById(long id)
        {
            var videogame = GetVideogameById(id);
            if (videogame == null)
                return;
            using VideogameContext db = new VideogameContext();
            db.Remove(videogame);
            db.SaveChanges();
        }

        public static bool InserisciSoftwareHouse(SoftwareHouse sh)
        {
            try
            {
                using VideogameContext db = new VideogameContext();
                db.Add(sh);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static List<SoftwareHouse> GetAllSoftwareHouses()
        {
            using VideogameContext db = new VideogameContext();
            return db.SoftwareHouses.ToList();
        }

        public static SoftwareHouse GetSoftwareHouseById(long id)
        {
            using VideogameContext db = new VideogameContext();
            return db.SoftwareHouses.Where(x => x.Id == id).Include(x => x.Videogames).FirstOrDefault();
        }
    }
}
