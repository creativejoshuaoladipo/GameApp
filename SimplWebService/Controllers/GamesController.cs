using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimplWebService.SimplWebService.Data.DataContext;
using SimplWebService.SimplWebService.Data.Models.Domain;
using SimplWebService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SimplWebService.Controllers
{
  
    [Route("simple-api")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly GamesDBContext _dBContext;
        public GamesController(GamesDBContext dbContext)
        {
            _dBContext = dbContext;
        }


        
        [HttpGet("get-games")]
        //[ProducesResponseType(typeof(ResponseModel), 200)]
        public IActionResult Get()
        {
            var gamelist = _dBContext.Games.ToList();

            var response = new ResponseModel
            {
                StatusCode = HttpStatusCode.OK,
                Message = "The games were successfully found",
                Data = gamelist
            };
            return Ok(response);
        }

        //[Authorize]
        [Authorize(AuthenticationSchemes =JwtBearerDefaults.AuthenticationScheme, Roles = "Administrators")]
        [HttpPost("save-game")]
        public IActionResult Post([FromBody] GamesVM gamesVM)
        {
            var game = _dBContext.Games.FirstOrDefault(game => game.Title == gamesVM.Title);
            if (game == null)
            {
                var gameModel = new Game
                {
                    Manufacturer = gamesVM.Manufacturer,
                    Maximum = gamesVM.Maximum,
                    MinimumPlayers = gamesVM.MinimumPlayers,
                    Title = gamesVM.Title
                };

                _dBContext.Games.Add(gameModel);

                _dBContext.SaveChanges();

                return StatusCode(StatusCodes.Status201Created);
            }

            return BadRequest(gamesVM);
        }

        [HttpGet("get-games-id/{id}")]
        public IActionResult GetGamesById(int id)
        {

            var game = _dBContext.Games.FirstOrDefault(s => s.Id == id);

            if(game == null)
            {
                return NotFound(id);
            }


            var response = new ResponseModel
            {
                StatusCode = HttpStatusCode.OK,
                Message = $" Game with id: {id} was succeffully found",
                Data = game

            };

            return Ok(response);
        }
    }
}
