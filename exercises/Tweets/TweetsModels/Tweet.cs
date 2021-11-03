using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PromptCLI;

namespace TweetsModels
{
    public class Tweet
    {
        [Display(Name = "Tweet ID")]
        public int Id { get; set; }

        [Display(Name = "Tweet Text"), Input("Tweet:")]
        public string Text { get; set; }

        [Display(Name = "Usename"), Input("Username:")]
        public string User { get; set; }

        [Display(Name = "Tweeted At")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "Likes")]
        public int LikesCount { get; set; } = 0;

        [Display(Name = "Retweets")]
        public int RetweetsCount { get; set; } = 0;

        [Display(Name = "Replies")]
        public int RepliesCount { get; set; } = 0;

        public override string ToString()  {
            return $"{Id} - {Text} (@{User})";
        }

        // Display tweet
        public void Display()
        {
            string lastLine = $"{RetweetsCount} Retweets - {LikesCount} Likes - {RepliesCount} Respostas";

            var textLines = new List<string>();

            for (int start = 0; start < Text.Length; start += lastLine.Length)
            {
                var end = lastLine.Length;
                if (end > Text.Length) end = Text.Length;

                try {
                    var textLine = Text.Substring(start, end);
                    textLines.Add(textLine);
                } catch (Exception) {
                    var textLine = Text.Substring(start);
                    textLines.Add(textLine);
                }
            }

            string result = "";

            result += $"{Id}\n";
            result += $"=={new string('=', lastLine.Length + 2)}==\n";
            result += $"|| @{User}{new string(' ', lastLine.Length - User.Length - 1)} ||\n";
            result += $"|| {new string(' ', lastLine.Length)} ||\n";

            foreach (var textLine in textLines)
            {
                result += $"|| {textLine}{new string(' ', lastLine.Length - textLine.Length)} ||\n";
            }

            result += $"|| {new string(' ', lastLine.Length)} ||\n";
            result += $"|| {lastLine} ||\n";
            result += $"=={new string('=', lastLine.Length + 2)}==\n";

            Console.WriteLine(result);
        }

        // Get all tweets
        public static List<Tweet> GetAll()
        {
            var conn = Database.GetConnection();
            conn.Open();

            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM tweet";
            var reader = cmd.ExecuteReader();

            var tweets = new List<Tweet>();

            while (reader.Read())
            {
                var tweet = new Tweet
                {
                    Id = reader.GetInt32(0),
                    Text = reader.GetString(1),
                    User = reader.GetString(2),
                    CreatedAt = reader.GetDateTime(3),
                    LikesCount = reader.GetInt32(4),
                    RetweetsCount = reader.GetInt32(5),
                    RepliesCount = reader.GetInt32(6)
                };

                tweets.Add(tweet);
            }

            conn.Close();
            return tweets;
        }
    
        public void Update(string newTweetText)
        {
            var conn = Database.GetConnection();
            conn.Open();

            var cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE tweet SET text = @text WHERE id = @id";
            cmd.Parameters.AddWithValue("@text", newTweetText);
            cmd.Parameters.AddWithValue("@id", Id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Delete()
        {
            var conn = Database.GetConnection();
            conn.Open();

            var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM tweet WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", Id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        // Save tweet on database
        public void Save()
        {
            var conn = Database.GetConnection();
            conn.Open();

            var cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO tweet (text, user, created_at, likes_count, retweets_count, replies_count) VALUES (@text, @user, @created_at, @likes_count, @retweets_count, @replies_count)";
            cmd.Parameters.AddWithValue("@text", Text);
            cmd.Parameters.AddWithValue("@user", User);
            cmd.Parameters.AddWithValue("@created_at", CreatedAt);
            cmd.Parameters.AddWithValue("@likes_count", LikesCount);
            cmd.Parameters.AddWithValue("@retweets_count", RetweetsCount);
            cmd.Parameters.AddWithValue("@replies_count", RepliesCount);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
