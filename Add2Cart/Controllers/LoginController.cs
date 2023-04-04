using Add2Cart.Interface;
using Add2CartModels;
using Microsoft.AspNetCore.Mvc;

namespace Add2Cart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly Ilogin LoginData;

        public LoginController(Ilogin Data)
        {
           LoginData = Data;
        }
        [HttpPost]
        [Route("create")]
        public IActionResult Add(Login Data)

        {
            LoginData.AddUser(Data);
            return Created("/" + Data, Data);


        }

        [HttpGet]
        [Route("get")]
        public IActionResult Get()
        {
            var data = LoginData.Get();
            return Ok(data);
        }

    }
}
