using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram_bot_starter.Core;
using Telegram_bot_starter.Models;

namespace Telegram_bot_starter.Controllers.Base
{
    class ConversationController : BaseController
    {
        [MessageReaction(ChatAction.Typing)]
        public void Start(MessageEventArgs message)
        {
            const string usage = "Start method in `ConversationController`\n\n" +
            "/me    - info about me\n" +
            "/help    - help\n" +
            "/inline   - send inline keyboard\n";

            CoreBot.SendMessage(ChatId, usage, ParseMode.MarkdownV2);
        }
    }
}
