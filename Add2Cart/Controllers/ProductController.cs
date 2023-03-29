using Add2Cart.Interface;
using Add2CartModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using static Add2Cart.Interface.Iproducts;

namespace Add2Cart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly Iproducts ProductData;

        public ProductController(Iproducts Data)
        {
            ProductData = Data;
        }


        [HttpPost]
        [Route("create")]
        public IActionResult Add(Product Data)

        {
            ProductData.Add(Data);
            return Created("/" + Data, Data);


        }

        [HttpGet]
        [Route("get")]
        public IActionResult Get()
        {
            var data = ProductData.Get();
            return Ok(data);
        }



        [HttpGet]
        [Route("getProducts/{category}")]
        public IActionResult GetLeavedatabyid(int category)
        {
            var DatabyID = ProductData.Getbycategory(category);
            if (DatabyID != null)
            {
                return Ok(DatabyID);
            }

            return NotFound($"Employee With Id : {category} Was Not Found");
        }

    }
}

