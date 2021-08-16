using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplWebService.ViewModels
{
    public class GamesVM
    {
        public string Title { get; set; }
        public string Manufacturer { get; set; }
        public int MinimumPlayers { get; set; }
        public int Maximum { get; set; }
    }
}
