using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITransactionService
    {
        //Transaction GetById(int TransactionId);
        IDataResult<Transaction> GetById(int transactionId);

        //List<Transaction> GetList();
        IDataResult<List<Transaction>> GetList();

        //void Add(Transaction transaction);
        IResult Add(Transaction transaction);

    }
}
