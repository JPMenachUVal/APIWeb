using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public decimal Monto { get; set; }
        public DateTime Date { get; set; }
    }
}