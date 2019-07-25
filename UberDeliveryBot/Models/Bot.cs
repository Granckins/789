
using MihaZupan;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using UberDeliveryBot.Models.Commands;

namespace UberDeliveryBot.Models
{
    public static class Bot
    {
        private static TelegramBotClient client;
        private static List<Command> commandsList;

        public static IReadOnlyList<Command> Commands => commandsList.AsReadOnly();

        public static async Task<TelegramBotClient> Get()
        {
            if (client != null)
            {
                return client;
            }

            commandsList = new List<Command>();
            commandsList.Add(new HelloCommand());
            commandsList.Add(new StartCommand());
            //TODO: Add more commands
            // using MihaZupan;

            var proxy = new HttpToSocks5Proxy("127.0.0.1", 1080);

         

            // Allows you to use proxies that are only allowing connections to Telegram
            // Needed for some proxies
            proxy.ResolveHostnamesLocally = true;
            client = new TelegramBotClient(AppSettings.Key,    new HttpToSocks5Proxy("127.0.0.1", 9050));
        
            var hook = string.Format(AppSettings.Url, "api/message/update");
            await client.SetWebhookAsync(hook);

            return client;
        }
    }
}