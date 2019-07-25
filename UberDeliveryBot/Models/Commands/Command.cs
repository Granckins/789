
using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

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
        public override string Name => "start";

        public override void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;
            client.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);
            client.SendTextMessageAsync(message.Chat.Id, "Введите пароль", replyMarkup: (new ForceReply() { Force = true })); 
            
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