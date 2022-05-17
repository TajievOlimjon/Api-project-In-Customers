using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public  interface IOrdersService
    {
        List<Orders> GetOrders();

        Orders GetOrdersBuId(int Id);

        int InsertOrders(Orders orders);
        int UpdateOrders(Orders orders,int Id);
        int DeleteOrders(int Id);
    }
}
