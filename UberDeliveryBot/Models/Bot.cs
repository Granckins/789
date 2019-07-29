
using MihaZupan;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Telegram.Bot;
using UberDeliveryBot.Models.Commands;

namespace UberDeliveryBot.Models
{
    class SaveXML
    {
        public static void SaveData(UserBot obj, string filename)
        {
            // initialization of XML serializer.
            XmlSerializer sr = new XmlSerializer(obj.GetType());
            // get stream from string
            TextWriter writer = new StreamWriter(filename);
            // Serialization 
            sr.Serialize(writer, obj);
            writer.Close();
        }

        public static List<UserBot> LoadData()
        {
            List<UserBot> users;
            using (var reader = new StreamReader("users.xml"))
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(List<UserBot>),
                    new XmlRootAttribute("user_list"));
                users = (List<UserBot>)deserializer.Deserialize(reader);
            }
            return users;
        }
    }
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