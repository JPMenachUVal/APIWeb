using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace DAL
{
    public class PersonMng
    {
        private string connectionString; // Establece tu cadena de conexión a la base de datos aquí

        public PersonMng(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AddUser(Person person)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Person (Name, Password) VALUES (@Name, @Password)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", person.Name);
                command.Parameters.AddWithValue("@Password", person.Password);
                command.ExecuteNonQuery();
            }
        }
        public List<Person> GetPersons()
        {
            List<Person> persons = new List<Person>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id, Name, Password FROM Person";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Person person = new Person
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"].ToString(),
                        Password = reader["Password"].ToString()
                    };
                    persons.Add(person);
                }
            }

            return persons;
        }

        public int DeletePersonsByName(string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Person WHERE Name = @Name";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);

                int affectedRows = command.ExecuteNonQuery();

                return affectedRows;
            }
        }

        public Person GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(Person person)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Person SET Name = @Name, Password = @Password WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", person.Name);
                command.Parameters.AddWithValue("@Password", person.Password);
                command.Parameters.AddWithValue("@Id", person.Id); // Asumiendo que person.Id contiene el ID del usuario a actualizar.
                command.ExecuteNonQuery();
            }
        }
    }
}