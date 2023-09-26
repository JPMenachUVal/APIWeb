using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entidades;

namespace LogicaNegocio.Services
{
    public class TransactionService
    {
        private readonly TransactionMng transactionMng;

        public TransactionService(string connectionString)
        {
            transactionMng = new TransactionMng(connectionString);
        }

        public List<Transaction> GetTransactions()
        {
            return transactionMng.GetTransactions();
        }

        public void AddTransaction(Transaction transaction)
        {
            // Aquí puedes realizar validaciones u operaciones adicionales antes de agregar la transacción.
            transactionMng.AddTransaction(transaction);
        }

        public List<Transaction> GetTransactionsByDate(DateTime date)
        {
            return transactionMng.GetTransactionsByDate(date);
        }

    }
}