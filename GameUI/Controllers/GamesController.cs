using GameUI.Services;
using GameUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameUI.Controllers
{
    public class GamesController : Controller
    {
        ApiService apiService;
        public GamesController()
        {
            apiService = new ApiService();
        }
        public async Task<IActionResult> Index()
        {
            var (result, message, gamesList) = await apiService.GetAllGames();
            if(result)
            {
                return View(gamesList);
            }

            return View(new List<GameVM>());
        }
    }
}
