using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UberDeliveryBot.Models
{
    public static class AppSettings
    {
        public static string Url { get; set; } = "https://telegrambotapp.azurewebsites.net:443/{0}";

        public static string Name { get; set; } = "Uber_delivery_bot";

        public static string Key { get; set; } = "725858124:AAHXsQdj72UADgvR4Y3XwFuH7e4M_QIN290";

    }
}