using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public int TransactionNo { get; set; }
        //para aktarım olup olmadıgı + veya -
        public decimal TransactionAmount { get; set; }
        //parayı gonderen kişi
        //public int TransactorAccountNumber { get; set; }
        //Parayı alan kişi
        //public int? ReceiverAccountNumber { get; set; }

        public DateTime? TransactionDate { get; set; }

        public decimal CurrencyUSD { get; set; }

        public decimal CurrencyEUR { get; set; }

        public decimal CurrencyXAU { get; set; }

        public bool IsSuccess { get; set; }

        //[Timestamp]
        //[ConcurrencyCheck]
        //public byte[] TimeStamp { get; set; }

        // Her işlemin bir müşteri
        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
