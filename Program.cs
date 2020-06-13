using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram_bot_starter.Controllers;
using Telegram_bot_starter.Core;

namespace Telegram_bot_starter
{
    class Program
    {
        public static void Main()
        {
            CoreBot.Init();
            CoreBot.StartReceiving();
        }
    }
}
