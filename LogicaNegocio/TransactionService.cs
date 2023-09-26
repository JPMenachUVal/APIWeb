using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entidades;

namespace LogicaNegocio
{
    public class TransactionService
    {
        private readonly TransactionMng TransactionMng;

        public TransactionService(string connectionString)
        {
            transactionMng = new transactionMng(connectionString);
        }

        public List<transaction> Gettransactions()
        {
            return transactionMng.Gettransactions();
        }

        public void CreateTransaction(transaction transaction)
        {
            // Aquí puedes realizar validaciones u operaciones adicionales antes de agregar el usuario.
            transactionMng.CreateTransaction(transaction);
        } 

        public transaction GetTransaction()
        {
            return transactionMng.GetTransaction();
        }
        public List<transaction> GetTransactionsByDateRange(DateTime startDate, DateTime endDate)
        {
            // Aquí puedes realizar validaciones u operaciones adicionales si es necesario
            return transactionMng.GetTransactionsByDateRange(DateTime startDate, DateTime endDate);
        }
    }
}