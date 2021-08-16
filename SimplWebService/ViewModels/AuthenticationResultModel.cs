using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplWebService.ViewModels
{
    public class AuthenticationResultModel
    {
        public string AccessToken { get; set; }
        public string ExpireInSeconds { get; set; }

    }
}
