using Domain;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace APIPractics.Controllers
{
   
    [ApiController]
    [Route( "api/[controller]")]
    public class OrdersController : Controller
    {
        private IOrdersService OrdersService;

        public OrdersController(IOrdersService OrdersService)
        {
            this.OrdersService = OrdersService;
        }

        [HttpGet("GetOrders")]
       public List<Orders> GetOrders()
        {
            return OrdersService.GetOrders();
        }


        //[HttpPost("InsertOrders")]
        //public int InsertOrders(Orders orders)
        //{
        //    return OrdersService.InsertOrders(orders);
        //}

        //[HttpPut("UpdateOrders")]
        //public int UpdateOrders(Orders orders,int Id)
        //{
        //    return OrdersService.UpdateOrders(orders,Id);

        //}
    }
}
