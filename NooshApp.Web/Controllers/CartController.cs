using Microsoft.AspNetCore.Mvc;

namespace NooshApp.Web.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index() => View();
    }
}