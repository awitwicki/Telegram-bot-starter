using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telegram_bot_starter.Core.Managers
{
    //Helper that parse command arguments for telegram buttons data
    public class ArgParser
    {
        public static Dictionary<string, string> ParseCallbackData(string query)
        {
            var returnDictionary = new Dictionary<string, string>();

            var queryArgs = query.Split('?').ToList();

            string methodName = queryArgs.First();
            methodName = methodName.First().ToString().ToUpper() + methodName.Substring(1);

            returnDictionary.Add("MethodName", methodName);

            if (query.Contains("?"))
            {
                var args = query.Split('?').Skip(1).FirstOrDefault()?.Split(',');

                foreach (var arg in args)
                {
                    var parsedArg = arg.Split("=");
                    returnDictionary.Add(parsedArg[0], parsedArg[1]);
                }
            }

            return returnDictionary;
        }
        public static Dictionary<string, object> ParseCommand(string query)
        {
            var returnDictionary = new Dictionary<string, object>();

            var queryArgs = query.Split(' ').ToList();

            string methodName = queryArgs.First().Trim('/');
            methodName = methodName.First().ToString().ToUpper() + methodName.Substring(1);

            returnDictionary.Add("MethodName", methodName);

            if (queryArgs.Count > 1)
                returnDictionary.Add("args", queryArgs.Skip(1).ToList());

            return returnDictionary;
        }
    }
}
