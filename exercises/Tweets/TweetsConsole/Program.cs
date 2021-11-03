using System;
using TweetsModels;
using PromptCLI;
using System.Collections.Generic;

namespace TweetsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true) {
                string option = GetMenuOption();

                switch (option)
                {
                    case "Create Tweet":
                        CreateTweet();
                        break;
                    case "Read Tweets":
                        ReadTweets();
                        break;
                    case "Update Tweet":
                        UpdateTweet();
                        break;
                    case "Delete Tweet":
                        DeleteTweet();
                        break;
                    case "Stop":
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }

        static string GetMenuOption()
        {
            string option = "";

            var prompt = new Prompt();

            prompt.Add(new SelectComponent<string>(
                    "Select what you want to do:",
                    new List<string>() {
                        "Create Tweet", "Read Tweets", "Update Tweet", "Delete Tweet", "Stop"
                    }
                ))
                .Callback(v => option = v);
            prompt.Begin();

            return option;
        }

        static Tweet GetTweetOption() {
            Tweet tweet = null;
            var prompt = new Prompt();

            prompt.Add(new SelectComponent<Tweet>(
                    "Select the tweet you want to update:",
                    Tweet.GetAll()
                ))
                .Callback(t => tweet = t);

            prompt.Begin();

            return tweet;
        }

        static void CreateTweet()
        {
            var prompt = new Prompt();
            Tweet tweet = prompt.Run<Tweet>();

            tweet.Text = tweet.Text.Trim();
            tweet.User = tweet.User.Trim();
            tweet.Save();
        }

        static void ReadTweets()
        {
            var tweets = Tweet.GetAll();
            foreach (var tweet in tweets) {
                tweet.Display();
            }

            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }

        static void UpdateTweet() {
            var tweet = GetTweetOption();

            var prompt = new Prompt();
                prompt
                    .Add(new InputComponent("Tweet: ", tweet.Text))
                    .Callback(text => tweet.Update(text.Trim()));

            prompt.Begin();
        }

        static void DeleteTweet() {
            var tweet = GetTweetOption();
            tweet.Delete();
        }
    }
}
