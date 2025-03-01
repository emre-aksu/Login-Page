using Microsoft.AspNetCore.Mvc;

namespace LogInPageUI.Areas.UserPanel.Controllers
{
    public class SuccessfulController : Controller 
    {
        [HttpGet]
        public IActionResult List()
        {
            return View();
        }
    }
}
