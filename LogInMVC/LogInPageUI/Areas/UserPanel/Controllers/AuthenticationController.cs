using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Dtos;
using System.Text.Json;

namespace LogInPageUI.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    public class AuthenticationController : Controller
    {
        private readonly IEmployeeManager _empMngr;
        public AuthenticationController(IEmployeeManager empMngr)
        {
            _empMngr = empMngr; 
        }
        [HttpGet]
        public IActionResult LogIn() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(LogInDto dto)
        {
            var user = await _empMngr.LogIn(dto);
            if (user == null)
            {
                return Json(new { IsSuccess = false, Message = "böyle bir kullanıcı yok" });
            }
            else
            {
                HttpContext.Session.SetString("LoggenInUser", JsonSerializer.Serialize(user));
                return Json(new { IsSuccess = true });
            }
        }
    }
}
