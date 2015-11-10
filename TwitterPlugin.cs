using System.Collections.Generic;
using CoreTweet;
using CoreTweet.Core;
using Newtonsoft.Json;
using System.IO;
using static CoreTweet.OAuth;
using System;

namespace Wox.Plugin.Twitter
{
    public class TwitterPlugin : IPlugin
    {
        private PluginInitContext context;
        public const string TOKEN_FILE_LOCATION = "Plugins\\Wox.Plugin.Twitter\\Properties\\secret.json";

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
            if(tokens != null)
            {
                try {
                    tokens.Statuses.Update(status => tweetString);
                }catch(Exception e)
                {}
            }
            else
            {
                var session = OAuth.Authorize(
                    "zeFOBi6OfV4KFpUNdiEN6hoWL",
                    "Wb6BmK3S1QOGt2MLtjNpepkObfMnWZkVGZ3T93x5qS1OpqtxbJ");
                var uri = session.AuthorizeUri;
                System.Diagnostics.Process.Start(uri.ToString());
                PINInputForm form = new PINInputForm(tweetString, session);
                form.Show();                
            }
        }

        private Tokens getTokens()
        {
            Tokens tokens;
            if (File.Exists(TOKEN_FILE_LOCATION))
            {
                Token token = JsonConvert.DeserializeObject<Token>(File.ReadAllText(TOKEN_FILE_LOCATION));
                tokens = Tokens.Create(
                    "zeFOBi6OfV4KFpUNdiEN6hoWL",
                    "Wb6BmK3S1QOGt2MLtjNpepkObfMnWZkVGZ3T93x5qS1OpqtxbJ",
                    token.AccessToken,
                    token.AccessTokenSecret
                    );
            }
            else
            {
                tokens = null;
            }
            return tokens;
        }
        
    }
}
