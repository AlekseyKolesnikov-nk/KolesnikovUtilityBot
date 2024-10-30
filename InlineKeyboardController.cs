using KolesnikovUtilityBot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Microsoft.Extensions.Hosting;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;

namespace KolesnikovUtilityBot
{
    public class InlineKeyboardController
    {
        //private readonly IStorage _memoryStorage;
        private readonly ITelegramBotClient _telegramClient;

        public InlineKeyboardController(ITelegramBotClient telegramBotClient)//, IStorage memoryStorage)
        {
            _telegramClient = telegramBotClient;
            //_memoryStorage = memoryStorage;
        }

        public async Task Handle(CallbackQuery? callbackQuery, CancellationToken ct)
        {
            if (callbackQuery?.Data == null)
                return;

            // Обновление пользовательской сессии новыми данными
            //_memoryStorage.GetSession(callbackQuery.From.Id).OptionCode = callbackQuery.Data;

            // Генерим информационное сообщение
            string optionText = callbackQuery.Data switch
            {
                "txt" => " Текст",
                "num" => " Числа",
                _ => string.Empty
            };

            //        $"<b>Язык аудио - {languageText}.{Environment.NewLine}</b>" +
            //        $"{Environment.NewLine}Можно поменять в главном меню.", cancellationToken: ct, parseMode: ParseMode.Html);
            //}


            // Отправляем в ответ уведомление о выборе
            await _telegramClient.SendTextMessageAsync(callbackQuery.From.Id,
                    $"<b> Выбрано - {optionText} {Environment.NewLine}</b>" +
                    $"{Environment.NewLine} Можно поменять в главном меню", cancellationToken: ct, parseMode: ParseMode.Html);
        }
    }
}
