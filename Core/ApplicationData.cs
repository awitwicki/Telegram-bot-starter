﻿using System;
using System.Collections.Generic;
using System.Linq;
using Telegram.Bot.Args;
using Telegram_bot_starter.Core.Managers;
using Telegram_bot_starter.Models;

namespace Telegram_bot_starter.Core
{
    public static class ApplicationData
    {
        public static string BotVersion = "1.1 Alpha";
        public static FileStorageManager<CoreBotUser> Users { get; set; } = new FileStorageManager<CoreBotUser>(Config.UsersFilePath);
        public static FileStorageManager<Stats> Stats { get; set; } = new FileStorageManager<Stats>(Config.StatsFilePath);

        public static CoreBotUser GetUser(CallbackQueryEventArgs callbackQueryEventArgs)
        {
            return GetUser(callbackQueryEventArgs.CallbackQuery.From.Id);
        }
        public static CoreBotUser GetUser(MessageEventArgs messageEventArgs)
        {
            return GetUser(messageEventArgs.Message.From.Id);
        }
        public static CoreBotUser GetUser(int userId)
        {
            return Users.Set().Where(u => u.Id == userId).FirstOrDefault();
        }
        public static CoreBotUser AddOrUpdateUser(CoreBotUser user)
        {
            var usr = Users.Set().FirstOrDefault(u => u.Id == user.Id);

            //Store Users
            if (usr == null)
            {
                //If new User then add
                Users.Add(user);

                Console.WriteLine($"New User {user.Name} {user.UserName}");
                //Bot.SendTextMessageAsync(Config.AdminId, $"New User {user.Name} {user.UserName}");
            }
            else
            {
                //Update User
                usr.ActiveAt = DateTime.UtcNow;
            }

            //Save to file
            ApplicationData.Users.SaveToFileAsync();

            return usr;
        }
        public static void SaveUsers()
        {
            //Save to file
            ApplicationData.Users.SaveToFileAsync();
        }
        public static void UpdateStats(Telegram.Bot.Types.User user)
        {
            var statsForToday = Stats.Set().Where(s => s.Date == DateTime.UtcNow.Date).FirstOrDefault();

            if (statsForToday == null)
            {
                //Create new day
                Stats.Add(new Stats
                {
                    ActiveClicks = 1,
                    Date = DateTime.UtcNow.Date,
                    UserId = new List<long>() { user.Id }
                });
            }
            else
            {
                statsForToday.ActiveClicks++;
                if (!statsForToday.UserId.Contains(user.Id))
                {
                    statsForToday.UserId.Add(user.Id);
                };
            }

            //Save to file
            Stats.SaveToFileAsync();
        }
    }
}