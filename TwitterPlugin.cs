using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreTweet;
using Newtonsoft.Json;
using System.IO;

namespace Wox.Plugin.Twitter
{
    public class TwitterPlugin: IPlugin
    {
        private PluginInitContext context;
        private CoreTweet.OAuth.OAuthSession session;

        private static string TOKEN_FILE_LOCATION = "Property\\token.json";

        public void Init(PluginInitContext context)
        {
            this.context = context;
        }

        public List<Result> Query(Query query)
        {
            List<Result> results = new List<Result>();
            results.Add(new Result()
            {
                Title = "Tweet: " + query.ToString(),
                IcoPath = "Image\\twitter.png",
                Action = context =>
                {
                    postTweet(query.ToString().Remove(0, 2));
                    return true;
                }
            });
            return results;
        }

        private void postTweet(string tweetString)
        {
            Tokens tokens = getTokens();
            if(tokens == null)
            {
                CoreTweet.OAuth.Authorize()
                PINInputForm form = new PINInputForm(tweetString);

            }
            tokens.Statuses.Update(status => tweetString);            
        }

        private Tokens getTokens()
        {
            Tokens tokens;
            if (File.Exists(TOKEN_FILE_LOCATION))
            {
                Token token = JsonConvert.DeserializeObject<Token>(File.ReadAllText(TOKEN_FILE_LOCATION));
                tokens = null;
            }
            else
            {
                tokens = null;
            }
            return tokens;
        }
        
    }
}
