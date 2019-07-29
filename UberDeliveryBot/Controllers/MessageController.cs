
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.ReplyMarkups;
using Uber.SDK;
using UberDeliveryBot.Models;
namespace UberDeliveryBot.Controllers
{
    public class MessageController : ApiController
    {
        [HttpGet]
        [Route(@"api/message/uber")] //webhook uri part
        public async Task<HttpResponseMessage> Uber(string code = "", string state="")
        {
            var path = "your path to index.html";
            var response = new HttpResponseMessage();
            response.Content = new StringContent("<html><body><a align = \"center\" style = \"color:#0088cc; font-size:30px\"  href=\"https://teleg.run/uber_delivery_bot\" ><h1>Авторизация прошла успешно. Вернуться в Telegram</h1> </a></body></html> ");
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            var authClient = new UberAuthenticationClient("rj7tZtjxSQwh7sxBDEZyU9Q5_10WBvPD", "lVtEEJJcJKSz_ie-8OSofKa6P9n_-gICXPx8ZyWh");
            var accessToken =  authClient.GetAccessTokenAsync(code, "https://fffb3ee5.ngrok.io/api/message/ubertoken");
            return response;
        }
        [HttpGet]
        [Route(@"api/message/ubertoken")] //webhook uri part
        public HttpResponseMessage UberToken(string access_token="", string expires_in = "", string token_type = "", string refresh_token = "", string scope = "")
        {
            var path = "your path to index.html";
            var response = new HttpResponseMessage();
            return response;
        }
        [Route(@"api/message/update")] //webhook uri part
        public async Task<OkResult> Update([FromBody]Update update)
        {
            var commands = Bot.Commands;
            var message = update.Message;
            var client = await Bot.Get();



            foreach (var command in commands)
            {
                if (command.Contains(message.Text))
                {
                    command.Execute(message, client);
                    break;
                }
            }

            if (message.Text == "/start")
            {
                var rkm = new ReplyKeyboardMarkup();
                rkm.OneTimeKeyboard = true;
                rkm.Keyboard =
             new KeyboardButton[][]
             {
        new KeyboardButton[]
        {
            new KeyboardButton("Заказ"),
            new KeyboardButton("item")
        },
          new KeyboardButton[]
        {
            new KeyboardButton("item")
        }
             };
                await client.SendTextMessageAsync(message.Chat.Id, "Выберете действие", ParseMode.Default, false, false, 0, replyMarkup: rkm );

            }
            return Ok();
        }

    }
}
