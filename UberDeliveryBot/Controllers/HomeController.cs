using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace UberDeliveryBot.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "It's my telega bot D:";
        }
        [HttpGet]
        public HttpResponseMessage Uber(string code, string state)
        {
             
            var response = new HttpResponseMessage();
            return response;
        }
    }
}