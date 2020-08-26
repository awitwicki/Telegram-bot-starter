using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram_bot_starter.Core.Managers;
using Telegram_bot_starter.Models;

namespace Telegram_bot_starter.Controllers
{
    public class CallbackController: BaseController
    {
        //Refresh weather
        public async Task Info(CallbackQueryEventArgs callbackQueryEventArgs)
        {
            //Simulate work
            await Task.Delay(1000);

            var weather = "The weather now is: " + "⛈🌧❄️☀️☁️"[new Random().Next(4)].ToString();
            //weather = "The weather now is: ";
            weather += $"\n`{DateTime.Now}`";
            weather += "\n@nameYourBot_bot";

            //Buttons menu
            var inlineKeyboard = new InlineKeyboardMarkup(new[]
            {
                new []
                {
                   InlineKeyboardButton.WithCallbackData("Refresh", $"{Commands.RefreshWeather}?{Commands.IsEdit}=true") //Thats is template how to pack commands with arguments
                }
            });

            //Check if clicked button "Refresh"
            var args = ArgParser.ParseCallbackData(callbackQueryEventArgs.CallbackQuery.Data);
            bool isEdit = args.ContainsKey(Commands.IsEdit);

            if (isEdit)
                EditMessageTextAsync(ChatId, MessageId, weather, ParseMode.Markdown, replyMarkup: inlineKeyboard);
            else
                SendMessage(ChatId, weather, ParseMode.Markdown, replyMarkup: inlineKeyboard);
        }
    }
}
