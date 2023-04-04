using Add2Cart.Services;
using Add2Cart.Interface;
using Add2CartModels;
using Microsoft.AspNetCore.Mvc;
using static Add2Cart.Interface.Icategory;

namespace Add2Cart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class category : Controller
    {
        private readonly Icategory CategoryData;

        public category(Icategory Data)
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

        [HttpGet]
        [Route("{Id}")]
        public IActionResult GetcategoryById(int Id)
        {
            var data = CategoryData.Getcategory(Id);
            if (data != null)
            {
                return Ok(data);
            }

            return NotFound($"Task with Id: {Id} was not found");
        }

        [HttpDelete]
        [Route("{Id}/delete")]
        public IActionResult Delete(int Id)
        {
            var data = CategoryData.Getcategory(Id);
            if (data != null)
            {
                CategoryData.DeleteCategory(data);
                return Ok("category Deleted");
            }
            return NotFound($"Task with Id: {Id} was not found");
        }
    }
}
