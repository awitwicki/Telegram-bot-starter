using System;
using System.Collections.Generic;
using System.Text;

namespace Telegram_bot_starter.Models
{
    public class CoreBotUser //: Telegram.Bot.Types.User
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public DateTime ActiveAt { get; set; }
        public long Id { get; set; }
        public UserAccess UserAccess { get; set; }
    }
}
