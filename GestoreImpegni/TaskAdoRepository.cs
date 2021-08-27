using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GestoreImpegni.Task;

namespace GestoreImpegni
{
    class TaskAdoRepository : ITaskRepository
    {
        const string connectionString = @"Data Source = (localdb)\mssqllocaldb;" +
                                        "Initial Catalog = GestoreTask;" +
                                        "Integrated Security = true;";
        public void Delete(Task task)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "delete from Task where Id = @id";
                command.Parameters.AddWithValue("@id", task.Id);

                command.ExecuteNonQuery();
            }
        }

        public List<Task> Fetch()
        {
            List<Task> tasks = new List<Task>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Task";

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var titolo = (string)reader["Titolo"];
                    var descrizione = (string)reader["Descrizione"];
                    var dataScadenza = (DateTime)reader["DataScadenza"];
                    var importanza = (Livello)reader["Importanza"];
                    var terminato = (bool)reader["Terminato"];
                    var id = (int)reader["Id"];

                    Task task = new Task(titolo, descrizione, dataScadenza, importanza, terminato, id);

                    tasks.Add(task);
                }
            }
            return tasks;
        }

        public List<Task> GetByTitle(string titolo)
        {
            List<Task> tasks = new List<Task>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Task where Titolo = @titolo";
                command.Parameters.AddWithValue("@titolo", titolo);
                
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    
                    var descrizione = (string)reader["Descrizione"];
                    var dataScadenza = (DateTime)reader["DataScadenza"];
                    var importanza = (Livello)reader["Importanza"];
                    var terminato = (bool)reader["Terminato"];
                    var id = (int)reader["Id"];

                    Task task = new Task(titolo, descrizione, dataScadenza, importanza, terminato, id);

                    tasks.Add(task);
                }
            }
            return tasks;
        }

        public List<Task> GetTerminated()
        {
            List<Task> tasks = new List<Task>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Task where Terminato = 1";

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var titolo = (string)reader["Titolo"];
                    var descrizione = (string)reader["Descrizione"];
                    var dataScadenza = (DateTime)reader["DataScadenza"];
                    var importanza = (Livello)reader["Importanza"];
                    var id = (int)reader["Id"];

                    Task task = new Task(titolo, descrizione, dataScadenza, importanza, true, id);

                    tasks.Add(task);
                }
            }
            return tasks;
        }

        public void Insert(Task task)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "insert into Task values (@titolo, @descrizione, @dataScadenza, @importanza, @terminato)";
                command.Parameters.AddWithValue("@titolo", task.Titolo);
                command.Parameters.AddWithValue("@descrizione", task.Descrizione);
                command.Parameters.AddWithValue("@dataScadenza", task.DataScadenza);
                command.Parameters.AddWithValue("@importanza", (int)task.Importanza);
                command.Parameters.AddWithValue("@terminato", task.IsTerminato);

                command.ExecuteNonQuery();
            }
        }

        public void Update(Task task)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "update Task set Titolo = @titolo, Descrizione = @descrizione, DataScadenza = @dataScadenza, Importanza = @importanza, Terminato = @terminato where Id = @id";
                command.Parameters.AddWithValue("@titolo", task.Titolo);
                command.Parameters.AddWithValue("@descrizione", task.Descrizione);
                command.Parameters.AddWithValue("@dataScadenza", task.DataScadenza);
                command.Parameters.AddWithValue("@importanza", (int)task.Importanza);
                command.Parameters.AddWithValue("@terminato", task.IsTerminato);
                command.Parameters.AddWithValue("@id", task.Id);

                command.ExecuteNonQuery();
            }
        }

        public List<Task> GetByImportanza(Task.Livello importanza)
        {
            List<Task> tasks = new List<Task>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Task where Importanza = @importanza";
                command.Parameters.AddWithValue("@importanza", (int)importanza);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var titolo = (string)reader["Titolo"];
                    var descrizione = (string)reader["Descrizione"];
                    var dataScadenza = (DateTime)reader["DataScadenza"];
                    var terminato = (bool)reader["Terminato"];
                    var id = (int)reader["Id"];

                    Task task = new Task(titolo, descrizione, dataScadenza, importanza, terminato, id);

                    tasks.Add(task);
                }
            }
            return tasks;
        }

        public List<Task> GetByDate(DateTime dS)
        {
            List<Task> tasks = new List<Task>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Task  where DataScadenza >= @dS order by DataScadenza ASC"; //faccio stampare in ordine crescente di data
                command.Parameters.AddWithValue("@dS", dS);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var titolo = (string)reader["Titolo"];
                    var descrizione = (string)reader["Descrizione"];
                    var dataScadenza = (DateTime)reader["DataScadenza"];
                    var importanza = (Livello)reader["Importanza"];
                    var terminato = (bool)reader["Terminato"];
                    var id = (int)reader["Id"];

                    Task task = new Task(titolo, descrizione, dataScadenza, importanza, terminato, id);

                    tasks.Add(task);
                }
            }
            return tasks;
        }


    }
}
