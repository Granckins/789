using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UberDeliveryBot.Models
{
    public class UserBot
    {
        public string ChartId { get; set; }
        public string LastMessage { get; set; }
        public bool IsLogin { get; set; }
    }
}