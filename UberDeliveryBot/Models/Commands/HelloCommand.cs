
using Telegram.Bot;
using Telegram.Bot.Types;

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
}