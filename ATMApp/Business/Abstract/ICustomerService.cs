using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        //Customer GetById(int customerId);
        IDataResult<Customer> GetById(int customerId);

        //List<Customer> GetList();
        IDataResult<List<Customer>> GetList();

        //void Add(Customer customer);
        IResult Add(Customer customer);

        //void Delete(Customer customer);
        IResult Delete(Customer customer);

        //void Update(Customer customer);
        IResult Update(Customer customer);
    }
}
