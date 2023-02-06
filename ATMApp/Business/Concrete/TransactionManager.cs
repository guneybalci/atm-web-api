using Business.Abstract;
using Business.Contants;
using Core.Utilities.Enums;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Business.Concrete
{
    public class TransactionManager : ITransactionService
    {
        private ITransactionDal _transactionDal;
        private ICustomerDal _customerDal;
        private IEmailService _emailService;
        public TransactionManager(ITransactionDal transactionDal, ICustomerDal customerDal,IEmailService emailService)
        {
            _transactionDal = transactionDal;
            _customerDal = customerDal;
            _emailService = emailService;
        }



        public IDataResult<Transaction> GetById(int transactionId)
        {
            return new SuccessDataResult<Transaction>(_transactionDal.Get(t => t.TransactionID == transactionId));
        }

        public IDataResult<List<Transaction>> GetList()
        {
            return new SuccessDataResult<List<Transaction>>(_transactionDal.GetList().ToList());
        }

        public IResult Add(Transaction transaction)
        {
            try
            {
                Customer c = _customerDal.Get(x => x.CustomerID == transaction.CustomerID);
                if (c.Balance + transaction.TransactionAmount >= 0)
                {
                    // TODO TRANSANCATION KAYIT EF TRANSACTION
                    c.Balance = c.Balance + transaction.TransactionAmount;
                    _customerDal.Update(c);
                    transaction.IsSuccess = true;
                    transaction.CurrencyEUR = (c.Balance+transaction.TransactionAmount)* (decimal)CurrencyType.EUR;
                    transaction.CurrencyUSD= (c.Balance + transaction.TransactionAmount) * (decimal)CurrencyType.USD;
                    transaction.CurrencyXAU = (c.Balance + transaction.TransactionAmount) * (decimal)CurrencyType.XAU;
                    var t = _transactionDal.GetList();
                    transaction.TransactionNo = 10000 + t.Count + 1;
                    _transactionDal.Add(transaction);
                    _emailService.SendEmail();
                    return new SuccessResult($"İşleminiz {transaction.TransactionNo} numarasıyla başarılı bir şekilde tamamlanmıştır. İşlem sonucundaki yeni bakiyeniz : {c.Balance}");
                }
                else
                {
                    transaction.IsSuccess = false;
                    _transactionDal.Add(transaction);
                    return new ErrorResult("Hesap bakiyeniz eksiye düşemez.");
                }
            }
            catch
            {
                transaction.IsSuccess = false;
                _transactionDal.Add(transaction);
                return new ErrorResult("İşlem yapılamadı. Daha sonra tekrar deneyiniz.");
            }
        }
    }
}
