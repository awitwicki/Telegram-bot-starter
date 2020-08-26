using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram_bot_starter.Models;

namespace Telegram_bot_starter.Controllers
{
    public class CommandController : BaseController
    {
        [MessageReaction(ChatAction.Typing)]
        public void Help(MessageEventArgs message)
        {
            const string usage = "Usage:\n" +
            "/me    - info about me\n" +
            "/help    - help\n" +
            "/inline   - send inline keyboard\n";

            SendMessage(ChatId, usage, replyMarkup: new ReplyKeyboardRemove());
        }

        [MessageReaction(ChatAction.Typing)]
        public void Inline(MessageEventArgs message)
        {
            // Simulate longer running task
            Task.Delay(500).Wait();

            var inlineKeyboard = new InlineKeyboardMarkup(new[]
            {
                // first row
                new []
                {
                    InlineKeyboardButton.WithCallbackData("weather", $"{Commands.RefreshWeather}"),
                    InlineKeyboardButton.WithCallbackData("strange command", "abc"),
                },
                // second row
                new []
                {
                    InlineKeyboardButton.WithCallbackData("strange command", "21"),
                    InlineKeyboardButton.WithCallbackData("strange command", "17"),
                }
            });

            SendMessage(ChatId, "Choose", replyMarkup: inlineKeyboard);
        }
        [MessageReaction(ChatAction.Typing)]
        public void Me(MessageEventArgs message)
        {
            string outpuitString = $"Your id is `{User.Id}`, chatid is `{ChatId}`";
            SendMessage(ChatId, outpuitString, ParseMode.MarkdownV2);
        }
        public async Task SendReplyKeyboard(Message message)
        {
            var replyKeyboardMarkup = new ReplyKeyboardMarkup(
                    new KeyboardButton[][]
                    {
                        new KeyboardButton[] { "1.1", "1.2" },
                        new KeyboardButton[] { "2.1", "2.2" },
                    },
                    resizeKeyboard: true
                );
            
            SendMessage(
                message.Chat.Id,
                "Choose",
                replyMarkup: replyKeyboardMarkup
            );
        }
    }
}
