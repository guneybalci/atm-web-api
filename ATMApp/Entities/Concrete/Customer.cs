using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Entities.Concrete
{
    public class Customer
    {
        public Customer()
        {
            Transactions = new List<Transaction>();
        }
        public int CustomerID { get; set; }

        public string CustomerName { get; set; }

        public string CustomerSurname { get; set; }

        public string CustomerPasskey { get; set; }

        public decimal Balance { get; set; }

        public byte BalanceType { get; set; }

        public bool IsActive { get; set; }

        // 1 müşteri 1'den çok Transaction'ı olabilir.
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
