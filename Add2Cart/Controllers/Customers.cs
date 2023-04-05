using Add2Cart.Interface;
using Add2CartModels;
using Microsoft.AspNetCore.Mvc;

namespace Add2Cart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Customers : Controller
    {
        private readonly Icustomer CustomerData;

        public Customers(Icustomer Data)
        {
            CustomerData = Data;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Add(Customer data)

        {
            CustomerData.AddToCustomerTable(data);
            return Created("/" + data, data);


        }

        [HttpGet]
        [Route("get")]
        public IActionResult Get()
        {
            var data = CustomerData.Get();
            return Ok(data);
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult GetcategoryById(int Id)
        {
            var data = CustomerData.GetDatasById(Id);

            if (data != null)
            {
                return Ok(data);
            }

            return NotFound($"Task with Id: {Id} was not found");
        }
    }
}
