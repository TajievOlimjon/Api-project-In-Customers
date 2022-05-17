using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Domain;
using Npgsql;

namespace Service
{
    public  class OrderService:IOrdersService
    {
        private string connectionString = "Server=localhost;port=5432;Database=Market;User Id=postgres;password=0711";

       

        public NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connectionString);
        }

       
        
        public List<Orders> GetOrders()
        {
            using (var connection=GetConnection())
            {
                var sql = "select  Orders.Id as OrderId,  C.FirstName,C.LastName,C.PhoneNumber,C.Address,P.Name,P.Price,P.MadeIn,P.Quantity,Orders.OrderDate from Orders " +
                           "  join Customer C on C.Id = Orders.CustomerId " +
                           "  join Product P on P.Id = Orders.ProductId ";

                var list = connection.Query<Orders>(sql);

                return list.ToList();

            }
        }

        public Orders GetOrdersBuId(int Id)
        {
            using (var connection =GetConnection())
            {
                var sql = $" select * from Orders Where Id={Id} ";
                var GetById=connection.ExecuteScalar<Orders>(sql);
                return GetById;
            }
        }

        public int InsertOrders(Orders orders)
        {
            using (var connection =GetConnection())
            {
                var sql =$" Insert into Orders(CustomerId,ProductId,OrderDate) " +
                    $"values({orders.CustomerId}," +
                    $"{orders.ProductId}," +
                    $"'{orders.OrderDate}')";
                var insert = connection.Execute(sql);
                return insert;

            }
        }

        public int UpdateOrders(Orders orders, int Id)
        {
            using (var connection = GetConnection())
            {
                var sql = $" Update Orders" +
                    $" set CustomerId={orders.CustomerId},ProductId={orders.ProductId},OrderDate='{orders.OrderDate}'" +
                    $"where Id={Id}";
                   
                var update = connection.Execute(sql);
                return update;

            }
        }

        public int DeleteOrders(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
