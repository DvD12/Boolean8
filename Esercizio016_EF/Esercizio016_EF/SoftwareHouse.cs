using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercizio016_EF
{
    public class SoftwareHouse
    {
        [Key] public int Id { get; set; }
        public string Name { get; set; }
        public string PIva { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public List<Videogame> Videogames { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public SoftwareHouse() { }
        public SoftwareHouse(string name, string pIva, string city, string country)
        {
            this.Name = name;
            this.PIva = pIva;
            this.City = city;
            this.Country = country;
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }
    }
}
