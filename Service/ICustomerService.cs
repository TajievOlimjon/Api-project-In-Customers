using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface ICustomerService
    {
         List<Customer> GetCustomer();

        Customer GetCustomerById(int Id);

        int InsertCustomer(Customer customer);

        int UpdateCustomer(Customer customer,int Id);

        int DeleteCustomer(int Id);


        
    }
}
