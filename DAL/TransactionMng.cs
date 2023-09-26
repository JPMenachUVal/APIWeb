using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;



namespace DAL
{
    public class TransaccionMng
    {
        private string connectionString; // Establece tu cadena de conexión a la base de datos aquí

        public TransaccionMng(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void AddTransaction(Transaction transaction)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Transaction (UserId, Description, Monto, Date) VALUES (@UserId, @Description, @Monto, @Date)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserId", transaction.UserId);
                command.Parameters.AddWithValue("@Description", transaction.Description);
                command.Parameters.AddWithValue("@Monto", transaction.Amount);
                command.Parameters.AddWithValue("@Date", transaction.Date);
                command.ExecuteNonQuery();
            }
        }
        public List<Transaction> GetAllTransactions()
        {
            List<Transaction> transactions = new List<Transaction>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Transaction";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Transaction transaction = new Transaction
                    {
                        TransactionId = (int)reader["TransactionId"],
                        UserId = (int)reader["UserId"],
                        Description = reader["Description"].ToString(),
                        Amount = (decimal)reader["Monto"],
                        Date = (DateTime)reader["Date"]
                    };
                    transactions.Add(transaction);
                }
            }
            return transactions;
        }

        public Transaction GetTransactionById(int transactionId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Transaction WHERE TransactionId = @TransactionId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TransactionId", transactionId);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Transaction transaction = new Transaction
                    {
                        TransactionId = (int)reader["TransactionId"],
                        UserId = (int)reader["UserId"],
                        Description = reader["Description"].ToString(),
                        Amount = (decimal)reader["Monto"],
                        Date = (DateTime)reader["Date"]
                    };
                    return transaction;
                }
                else
                {
                    return null; // Si no se encuentra la transacción con el ID dado
                }
            }
        }

        public List<Transaction> GetTransactionsByDateRange(DateTime startDate, DateTime endDate)
        {
            List<Transaction> transactions = new List<Transaction>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Transaction WHERE Date >= @StartDate AND Date <= @EndDate";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@EndDate", endDate);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Transaction transaction = new Transaction
                    {
                        TransactionId = (int)reader["TransactionId"],
                        UserId = (int)reader["UserId"],
                        Description = reader["Description"].ToString(),
                        Amount = (decimal)reader["Monto"],
                        Date = (DateTime)reader["Date"]
                    };
                    transactions.Add(transaction);
                }
            }
            return transactions;
        }

    }
}