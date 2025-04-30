using Microsoft.AspNetCore.Mvc;

namespace SignalR.Web.UI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
