using Add2Cart.Interface;
using Add2CartModels;
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
            OrderData.Add(data);
            return Created("/" + data, data);


        }

        [HttpGet]
        [Route("get")]
        public IActionResult Get()
        {
            var data = OrderData.Get();
            return Ok(data);
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult GetyById(int Id)
        {
            var data = OrderData.GetById(Id);

            if (data != null)
            {
                return Ok(data);
            }

            return NotFound($"Task with Id: {Id} was not found");
        }
    }
}
