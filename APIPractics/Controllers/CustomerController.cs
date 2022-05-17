using Microsoft.AspNetCore.Mvc;
using Domain;
using Service;

namespace APIPractics.Controllers
{
    [ApiController]
    [Route ("api/[controller]")]
    public class CustomerController : Controller
    {
        private ICustomerService CustomerService;

        public CustomerController(ICustomerService CustomerService)
        {
            this.CustomerService = CustomerService;
        }

        [HttpGet("GetCustomers")]
        public List<Customer> GetCustomers()
        {
            return CustomerService.GetCustomer();
        }

        [HttpGet("GetCustomerById")]
        public Customer GetCustomerById(int Id)
        {
            return CustomerService.GetCustomerById(Id);
        }

        [HttpPost("InsertCustomer")]
        public int InsertCustomer(Customer customer)
        {
            return CustomerService.InsertCustomer(customer);
        }

        [HttpPut("UpdateCustomer")]
        public int UpdateCustomer(Customer customer,int Id)
        {
            return CustomerService.UpdateCustomer(customer,Id);

        }

        [HttpDelete("DeleteCustomer")]
        public int DeleteCustomer(int Id)
        {
            return CustomerService.DeleteCustomer(Id);

        }



    }
}
