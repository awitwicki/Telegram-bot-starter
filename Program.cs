using System;
using Telegram_bot_starter.Core;

namespace Telegram_bot_starter
{
    class Program
    {
        public static void Main()
        {
            var corebot = new CoreBot(Config.TelegramAccessToken);
            while (true) { }
        }
    }
}
