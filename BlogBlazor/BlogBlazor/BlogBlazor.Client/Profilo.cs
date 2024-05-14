namespace BlogBlazor.Client
{
    public class Profilo
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }

        public Profilo() { }
        public Profilo(string nome, string cognome)
        {
            Nome = nome;
            Cognome = cognome;
        }
    }
}
