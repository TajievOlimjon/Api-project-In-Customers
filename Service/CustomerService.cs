using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Domain;

namespace Service
{
    public  class CustomerService:ICustomerService
    {

        private string connectionString = "Server=localhost;port=5432;Database=Market;User Id=postgres;password=0711";



        public NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connectionString);
        }

        public List<Customer> GetCustomer()
        {
            using (var connection=GetConnection())
            {
                var sql = " select * from Customer ";
                var list = connection.Query<Customer>(sql);
                return list.ToList();

            }
        }

        public Customer GetCustomerById(int Id)
        {
            using (var connection = GetConnection())
            {
                var sql = $" select * from Customer Where Id={Id} ";
                var GetById = connection.QuerySingle<Customer>(sql);
                return GetById;

            }
        }

        public int InsertCustomer(Customer customer)
        {
            using (var connection = GetConnection())
            {
                var sql = $" Insert into Customer(FirstName,LastName,PhoneNumber,Address,Email,BirthDate)" +
                    $" Values(" +
                    $" '{customer.FirstName}'," +
                    $" '{customer.LastName}'," +
                    $" {customer.PhoneNumber}," +
                    $" '{customer.Address}'," +
                    $" '{customer.Email}'," +
                    $" '{customer.BirthDate}') ";
                var insert = connection.Execute(sql);
                return insert;

            }
        }

        public int UpdateCustomer(Customer customer, int Id)
        {
            using (var connection = GetConnection())
            {
                var sql = $" Update Customer " +
                    $" Set " +
                    $" FirstName='{customer.FirstName}'," +
                    $" LastName='{customer.LastName}'," +
                    $" PhoneNumber={customer.PhoneNumber}," +
                    $" Address='{customer.Address}'," +
                    $" Email='{customer.Email}'," +
                    $" BirthDate='{customer.BirthDate}' " +
                    $" Where Id={Id} ";
                var update = connection.Execute(sql);
                return update;

            }
        }

        public int DeleteCustomer(int Id)
        {
            using (var connection=GetConnection())
            {
                var sql = $" Delete from Customer Where Id={Id} ";
                var delete= connection.Execute(sql);
                return delete;
            }
        }
    }
}
