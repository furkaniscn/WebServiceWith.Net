using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;

namespace test.Controllers
{
    public class CustomAuthentication : SoapHeader
    {
        public static string UserName { get; set; }
        public static  string Password { get; set; }
    }
}