using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DbConServRef;

namespace ToDoList_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListWebApiController : ControllerBase
    {
        Service1Client cliente = new Service1Client();

    }
}
