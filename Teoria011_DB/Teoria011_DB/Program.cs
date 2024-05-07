using System.Data.SqlClient;

namespace Teoria011_DB
{
    internal class Program
    {
        public const string STRINGA_DI_CONNESSIONE = "Data Source=localhost;Initial Catalog=MioDatabase3;Integrated Security=True";
        static void Main(string[] args)
        {
            //Insert("Campo minato", "Ora prato fiorito");
            //Update();
            //Delete();
            Transazione();
        }

        public static void Insert(string nome, string descrizione)
        {
            using SqlConnection connessioneSql = new SqlConnection(STRINGA_DI_CONNESSIONE);
            try
            {
                connessioneSql.Open();
                string query = @"INSERT INTO videogames (name, overview, release_date, created_at, updated_at, software_house_id)
VALUES (@name, @overview, @release_date, @created_at, @updated_at, @sh_id)";

                using SqlCommand cmd = new SqlCommand(query, connessioneSql);
                InsertInternal(cmd, nome, descrizione);
            }
            catch (Exception ex)
            { }
        }
        public static int InsertInternal(SqlCommand cmd, string nome, string descrizione)
        {
            cmd.Parameters.Add(new SqlParameter("@name", nome));
            cmd.Parameters.Add(new SqlParameter("@overview", descrizione));
            cmd.Parameters.Add(new SqlParameter("@release_date", "1985-01-01"));
            cmd.Parameters.Add(new SqlParameter("@created_at", "1985-01-01"));
            cmd.Parameters.Add(new SqlParameter("@updated_at", "2002-01-01"));
            cmd.Parameters.Add(new SqlParameter("@sh_id", "1"));

            int affectedRows = cmd.ExecuteNonQuery();
            return affectedRows;
        }
        public static void Update()
        {
            using SqlConnection connessioneSql = new SqlConnection(STRINGA_DI_CONNESSIONE);
            try
            {
                connessioneSql.Open();
                string query = @"UPDATE videogames SET overview=@overview WHERE name=@name;";

                using SqlCommand cmd = new SqlCommand(query, connessioneSql);
                cmd.Parameters.Add(new SqlParameter("@name", "Campo minato"));
                cmd.Parameters.Add(new SqlParameter("@overview", "Ora prato fiorito 2"));

                int affectedRows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            { }
        }
        public static void Delete()
        {
            using SqlConnection connessioneSql = new SqlConnection(STRINGA_DI_CONNESSIONE);
            try
            {
                connessioneSql.Open();
                string query = @"DELETE FROM videogames WHERE name=@name;";

                using SqlCommand cmd = new SqlCommand(query, connessioneSql);
                cmd.Parameters.Add(new SqlParameter("@name", "Campo minato"));

                int affectedRows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            { }
        }

        public static void Transazione()
        {
            using SqlConnection connessioneSql = new SqlConnection(STRINGA_DI_CONNESSIONE);

            try
            {
                connessioneSql.Open();

                // Anziché new SqlCommand(query, connessioneSql)
                // usiamo connessioneSql.CreateCommand(), che
                //  1. avrà "di default" connessioneSql come connessione (essendo l'oggetto che chiama CreateCommand() assegnerà a cmd la connessione in qualche modo
                //  2. NON avrà nessuna query assegnata al momento, perché vogliamo eseguire più di una query manualmente con la stessa connessione
                using SqlCommand cmd = connessioneSql.CreateCommand(); // Assegniamo query in un secondo momento
                // La transaction rappresenta un "blocco unico", una singola istruzione indivisibile, atomica:
                // Finché non viene chiama la commit i comandi SQL eseguiti al suo interno NON hanno nessun
                // effetto visibile sul nostro database
                using (SqlTransaction transaction = connessioneSql.BeginTransaction("TransazioneEsempio"))
                {
                    // Bisogna assegnare al SqlCommand la transaction richiesta!
                    cmd.Transaction = transaction;

                    try
                    {
                        // Tramite CommandText assegniamo a cmd la query che vogliamo eseguire
                        cmd.CommandText = @"INSERT INTO videogames (name, overview, release_date, created_at, updated_at, software_house_id)
VALUES ('Campo minato', 'Overview', '1985-01-01', '1985-01-01', '1985-01-01', 1)";
                        cmd.ExecuteNonQuery(); // anche se abbiamo eseguito il comando, il database non è stato ancora toccato
                        // Possiamo eseguire altre query assegnando un altro valore a CommandText
                        cmd.CommandText = @"INSERT INTO videogames (name, overview, release_date, created_at, updated_at, software_house_id)
VALUES ('Campo minato 2', 'Overview', '1985-01-01', '1985-01-01', '1985-01-01', 1)";
                        cmd.ExecuteNonQuery();

                        // Faccio il commit della transazione: ORA il database vede le modifiche
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // Se non va a buon fine torno indietro
                        transaction.Rollback();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void LeggiJoin()
        {
            using SqlConnection connessioneSql = new SqlConnection(STRINGA_DI_CONNESSIONE);

            try
            {
                connessioneSql.Open();
                string query = @"SELECT DISTINCT videogames.name as VideogameName, pegi_labels.name as PegiName
FROM videogames
INNER JOIN reviews ON videogames.id = reviews.videogame_id
INNER JOIN category_videogame ON category_videogame.videogame_id = videogames.id
INNER JOIN categories ON category_videogame.category_id = categories.id
INNER JOIN pegi_label_videogame ON pegi_label_videogame.videogame_id = videogames.id
INNER JOIN pegi_labels ON pegi_label_videogame.pegi_label_id = pegi_labels.id
WHERE reviews.rating >= @rating_value";
                using SqlCommand cmd = new SqlCommand(query, connessioneSql);
                cmd.Parameters.Add(new SqlParameter("@rating_value", 4));
                using SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int indiceVideogameName = reader.GetOrdinal("VideogameName");
                    int indicePegiName = reader.GetOrdinal("PegiName");
                    Console.WriteLine($"Videogame {reader.GetString(indiceVideogameName)}, categoria {reader.GetString(indicePegiName)}");
                }
            }
            catch (Exception ex)
            { }
        }

        public static void ConnessioneSenzaUsing()
        {
            SqlConnection connessioneSql = new SqlConnection(STRINGA_DI_CONNESSIONE);
            try
            {
                connessioneSql.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                connessioneSql.Close();
            }
        }
        public static void ConnessioneConUsing()
        {
            // "using" chiama automaticamente il metodo IDisposable.Dispose(), il quale a sua volta chiamerà eventualmente Close()
            // Lo chiama alla fine dello scope di using, cioè una volta terminate le sue {}
            using (SqlConnection connessioneSql = new SqlConnection(STRINGA_DI_CONNESSIONE))
            {
                try
                {
                    connessioneSql.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
        public static void ConnessioneConUsing2()
        {
            // "using" senza {} termina quando termina lo scope in cui è incluso lo using,
            // che in questo caso è lo scope della funzione stessa
            using SqlConnection connessioneSql = new SqlConnection(STRINGA_DI_CONNESSIONE);

            try
            {
                connessioneSql.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
