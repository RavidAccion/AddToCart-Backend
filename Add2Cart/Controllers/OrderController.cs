using Add2Cart.Interface;
using Add2CartModels;
using Add2CartModels.SPModels;
using Microsoft.AspNetCore.Mvc;

namespace Add2Cart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly Iorder OrderData;

        public OrderController(Iorder Data)
        {
            OrderData = Data;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Add(Order data)

        {
            data.placed_on = DateTime.Now;
            var today = DateTime.Today;
            var delivery = today.AddDays(3);
            data.delivery = delivery;
            OrderData.Add(data);
            OrderData.updateStockOrder(data);
            return Created("/" + data, data);


        }

        [HttpGet]
        [Route("get")]
        public IActionResult Get()
        {
            var data = OrderData.Get();
            return Ok(data);
        }

        [HttpPut]
        [Route("edit")]
        public IActionResult editStatus(OrderDetails data)
        {
            var Data = OrderData.updateOrder(data);
            return Ok(Data);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOrdersById(int id)
        {
            List<GetOrder> Cart = OrderData.GetById(id);
            if (Cart != null)
            {
                return Ok(Cart);
            }

            return NotFound($"Order with UserId: {id} was not found");
        }


 /*       [HttpGet]
        [Route("cart/{Id}")]
        public IActionResult GetyById(int Id)
        {
            var data = OrderData.GetById(Id);

            if (data != null)
            {
                return Ok(data);
            }

            return NotFound($"Order with userId: {Id} was not found");
        }*/

        [HttpDelete]
        [Route("cart/{Id}/delete")]
        public IActionResult Delete(int Id)
        {
            var data = OrderData.Getcart(Id);
            if (data != null)
            {
                OrderData.DeleteCart(data);
                return Ok("Cart Item Deleted");
            }
            return NotFound($"Task with Id: {Id} was not found");
        }
    }
}
