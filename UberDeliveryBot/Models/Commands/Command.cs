
using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using System.Net;
using System.IO;
using Uber.SDK;
using Telegram.Bot.Types.ReplyMarkups;

namespace UberDeliveryBot.Models.Commands
{
    public class HelloCommand : Command
    {
        public override string Name => "hello";

        public override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;

            //TODO: Command logic -_-
            client.SendTextMessageAsync(message.Chat.Id, "Thx for the Pics");
            client.SendTextMessageAsync(chatId, "Hello!", replyToMessageId: messageId);
        }
    }
    public class StartCommand : Command
    {
        public override string Name => "Заказ";

        public override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            //var request = (HttpWebRequest)WebRequest.Create("https://login.uber.com/oauth/v2/authorize?client_id=rj7tZtjxSQwh7sxBDEZyU9Q5_10WBvPD&response_type=code&redirect_uri=https://fffb3ee5.ngrok.io/api/message/uber&state="+ chatId);

            //var response = (HttpWebResponse)request.GetResponse();

            //var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            var authClient = new UberAuthenticationClient("rj7tZtjxSQwh7sxBDEZyU9Q5_10WBvPD", "lVtEEJJcJKSz_ie-8OSofKa6P9n_-gICXPx8ZyWh");
            // Generate authorize URL - If you don't specify scope, state or redirect URI then app defaults will be used
            var authorizeUrl = authClient.GetAuthorizeUrl(null,chatId.ToString(),null);
            var keyboard = new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup(new[]
{
    new [] // first row
    {
        InlineKeyboardButton.WithUrl("Войти через Uber",authorizeUrl) 
    }
});
             client.SendTextMessageAsync(chatId, "Віберете действие!", replyMarkup: keyboard);

        }
    }
    public abstract class Command
    {
        public abstract string Name { get; }

        public abstract void Execute(Message message, TelegramBotClient client);

        public bool Contains(string command)
        {
            return command.Contains(this.Name);
        }

    }
}