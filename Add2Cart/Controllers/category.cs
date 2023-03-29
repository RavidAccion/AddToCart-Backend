using Add2Cart.Services;
using Add2Cart.Interface;
using Add2CartModels;
using Microsoft.AspNetCore.Mvc;
using static Add2Cart.Interface.ICategory;

namespace Add2Cart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class category : Controller
    {
        private readonly ICategory CategoryData;

        public category(ICategory Data)
        {
            CategoryData = Data;
        }


        [HttpPost]
        [Route("create")]
        public IActionResult Add(Category data)

        {
            CategoryData.Add(data);
            return Created("/" + data, data);


        }

        [HttpGet]
        [Route("get")]
        public IActionResult Get()
        {
            var data = CategoryData.Get();
            return Ok(data);
        }
    }
}
