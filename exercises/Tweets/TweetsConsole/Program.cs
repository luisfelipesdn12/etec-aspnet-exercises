using System;
using TweetsModels;

namespace TweetsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var tweet = new Tweet{
                Id = 1,
                Text = "Hello World!",
                CreatedAt = DateTime.Now,
                User = "luisfelipesdn12",
                LikesCount = 0,
                RetweetsCount = 0,
                RepliesCount = 0
            };

            Console.WriteLine(tweet.Text);

            tweet.Save();
        }
    }
}
