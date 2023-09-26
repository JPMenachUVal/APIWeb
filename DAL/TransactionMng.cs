using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Entidades;

 

namespace DAL
{
    public class TransactionMng
    {
        private string connectionString; // Establece tu cadena de conexión a la base de datos aquí

 

        public TransactionMng(string connectionString)
        {
            this.connectionString = connectionString;
        }

 

        public void AddTransaction(Transaction transaction)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO [Transaction] (UserId, Description, Monto, Date) " +
                               "VALUES (@UserId, @Description, @Monto, @Date)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserId", transaction.UserId);
                command.Parameters.AddWithValue("@Description", transaction.Description);
                command.Parameters.AddWithValue("@Monto", transaction.Monto);
                command.Parameters.AddWithValue("@Date", transaction.Date);
                command.ExecuteNonQuery();
            }
        }

 

        public List<Transaction> GetTransactions()
        {
            List<Transaction> transactions = new List<Transaction>();

 

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT TransactionId, UserId, Description, Monto, Date FROM [Transaction]";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

 

                while (reader.Read())
                {
                    Transaction transaction = new Transaction
                    {
                        TransactionId = (int)reader["TransactionId"],
                        UserId = (int)reader["UserId"],
                        Description = reader["Description"].ToString(),
                        Monto = (decimal)reader["Monto"],
                        Date = (DateTime)reader["Date"]
                    };
                    transactions.Add(transaction);
                }
            }

 

            return transactions;
        }

 

        public List<Transaction> GetTransactionsByDate(DateTime date)
        {
            List<Transaction> transactions = new List<Transaction>();

 

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT TransactionId, UserId, Description, Monto, Date " +
                               "FROM [Transaction] " +
                               "WHERE Date >= @StartDate AND Date < @EndDate";
                SqlCommand command = new SqlCommand(query, connection);

 

                // Calcular la fecha de inicio (00:00:00) del día proporcionado
                DateTime startDate = date.Date;

 

                // Calcular la fecha de finalización (00:00:00) del día siguiente al proporcionado
                DateTime endDate = startDate.AddDays(1);

 

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
                        Monto = (decimal)reader["Monto"],
                        Date = (DateTime)reader["Date"]
                    };
                    transactions.Add(transaction);
                }
            }

 

            return transactions;
        }

 

 

    }
}