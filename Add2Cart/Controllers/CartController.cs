using Add2Cart.Interface;
using Add2CartModels;
using Microsoft.AspNetCore.Mvc;

namespace Add2Cart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : Controller
    {
        private readonly Icart CartData;

        public CartController(Icart Data)
        {
            CartData = Data;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Add(Cart data)

        {
            CartData.AddCartData(data);
           
            var Cart = CartData.Getbycart(data.customer_id);
            return Created("/" + Cart, Cart);


        }
        [HttpGet]
        [Route("get")]
        public IActionResult Get()
        {
            var data = CartData.Get();
            return Ok(data);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetcategoryById(int id)
        {
            var Cart = CartData.Getbycart(id);
            if (Cart != null)
            {
                return Ok(Cart);
            }

            return NotFound($"Task with Id: {id} was not found");
        }

        [HttpDelete]
        [Route("{Id}/delete")]
        public IActionResult Delete(int Id)
        {
            var data = CartData.Getcart(Id);
            if (data != null)
            {
                CartData.DeleteCart(data);
                return Ok("Cart Item Deleted");
            }
            return NotFound($"Task with Id: {Id} was not found");
        }
    }
}
