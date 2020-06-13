using System;
using System.Collections.Generic;
using System.Text;

namespace Telegram_bot_starter.Core
{
    public static class Config
    {
        public static string TelegramAccessToken = "TELEGRAM ACCESS TOKEN HERE";

        public static long AdminId = 0; //YOUR ID HERE, to get yout id, send /me to bot
        public static string DataPath = @"data/";
        public static string UsersFilePath = DataPath + @"users.json";
        public static string StatsFilePath = DataPath + @"stats.json";
    }
}
