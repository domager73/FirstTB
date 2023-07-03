using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types.ReplyMarkups;

namespace FirstTB
{
    internal class BotHandlers
    {
        public async static Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Message is not { } message) { return; }

            if (message.Text is not { } messageText) { return; }

            string response = "Неизвестная команда (для получения шутки введите /joke)";

            response = ResponseManager.GetResponseByName(messageText);

            Console.WriteLine(message.Chat.Id);
            Console.WriteLine(messageText);


            await botClient.SendTextMessageAsync
                (
                    chatId: message.Chat.Id,
                    text: response,
                    cancellationToken: cancellationToken
                );
        }

        public static Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }


    }
}
