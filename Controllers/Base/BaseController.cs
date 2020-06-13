﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram_bot_starter.Models;

namespace Telegram_bot_starter.Controllers
{
    public class BaseController
    {
        public CoreBotUser User { get; set; }
        public int MessageId { get; set; }
        public long ChatId { get; set; }

        public BaseController() { }
        public BaseController(CoreBotUser user, int messageId, long chatId)
        {
            User = user;
            MessageId = messageId;
            ChatId = chatId;
        }

        //Methods attributes
        public class MessageReaction : System.Attribute
        {
            public ChatAction ChatAction { get; set; }
            public MessageReaction(ChatAction chatAction)
            {
                this.ChatAction = chatAction;
            }
        }

        public class Role : System.Attribute
        {
            public UserAccess UserAccess { get; set; }
            public Role(UserAccess userAccess)
            {
                this.UserAccess = userAccess;
            }
        }


        //Attribute validators

        //Send chat action
        public static Nullable<ChatAction> GetChatActionAttributes(MethodInfo methodInfo)
        {
            Object[] attributes = methodInfo.GetCustomAttributes(true);

            //find and return chatAction
            foreach (var attribute in attributes)
            {
                if (attribute.GetType() == typeof(MessageReaction))
                {
                    var chatAction = ((MessageReaction)attribute).ChatAction;
                    return chatAction;
                }
            }

            return null;
        }

        //Validate user access role
        public static bool ValidateAccess(MethodInfo methodInfo, CoreBotUser user)
        {
            Object[] attributes = methodInfo.GetCustomAttributes(true);

            foreach (var attribute in attributes)
            {
                if (attribute.GetType() == typeof(Role))
                {
                    var access = ((Role)attribute).UserAccess;
                    if (user.UserAccess != access)
                    {
                        //CoreBot.SendMessage(chatId, "No access", ParseMode.Markdown);
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
