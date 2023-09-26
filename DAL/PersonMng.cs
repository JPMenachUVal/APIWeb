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
    }
}