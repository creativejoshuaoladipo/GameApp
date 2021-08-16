using GameUI.Services;
using GameUI.Utility;
using GameUI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace GameUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;
        ApiService apiService;


        public AuthController(ILogger<AuthController> logger)
        {
            apiService = new ApiService();
            _logger = logger;
        }



        [HttpPost]
        public async Task<IActionResult> Login(LoginVM login)
        {
            try
            {
                string message = "";
                if(login.UserName == "" || login.Password == "")
                {
                    message = "Username or Password is required";
                    return RedirectToAction("Login", new { errorMsg = message });

                  

                }

                var (result, response) = await apiService.Login(login);
                if(result)
                {
                    string accessToken = response;
                    CookieOptions options = new CookieOptions { HttpOnly = true };
                    Response.Cookies.Append(AppConstants.TokenKey, accessToken);
                    return RedirectToAction("Index", "Games");
                }

                string errorMessage = response;
                return RedirectToAction("Login", new { errorMsg = errorMessage });
             


            }
            catch (Exception ex)
            {
                _logger.LogError($"{MethodBase.GetCurrentMethod().Name}\n {ex.Message}\n {ex.StackTrace}");
                throw;
            }
        }


        [HttpGet]
        public IActionResult Login()
        {
            var loginVM = new LoginVM();
            return View(loginVM);
        }

    }
}
