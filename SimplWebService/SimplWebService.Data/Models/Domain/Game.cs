using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplWebService.SimplWebService.Data.Models.Domain
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Manufacturer { get; set; }
        public int MinimumPlayers { get; set; }
        public int Maximum { get; set; }

    }
}
