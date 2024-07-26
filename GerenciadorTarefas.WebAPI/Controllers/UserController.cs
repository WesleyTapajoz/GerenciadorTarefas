using Microsoft.AspNetCore.Mvc;

namespace GerenciadorTarefas.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
