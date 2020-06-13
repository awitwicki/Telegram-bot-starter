using System;
using System.Collections.Generic;
using System.Text;

namespace Telegram_bot_starter.Models
{
    public class Stats
    {
        public DateTime Date { get; set; }
        public long ActiveClicks { get; set; }
        public List<long> UserId { get; set; } = new List<long>();
    }
}
