namespace Teoria018_MVC.Models
{

    public class Profile
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public int Age { get; set; }

        public Profile() { }

        public Profile(string name, string lastname, int age)
        {
            this.Name = name;
            this.Lastname = lastname;
            this.Age = age;
        }

    }
}
