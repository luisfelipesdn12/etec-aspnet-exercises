using System;
using System.ComponentModel.DataAnnotations;

namespace TweetsModels
{
    public class Tweet
    {
        [Display(Name = "Tweet ID")]
        public int Id { get; set; }

        [Display(Name = "Tweet Text")]
        public string Text { get; set; }

        [Display(Name = "Usename")]
        public string User { get; set; }

        [Display(Name = "Tweeted At")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Likes")]
        public int LikesCount { get; set; }

        [Display(Name = "Retweets")]
        public int RetweetsCount { get; set; }

        [Display(Name = "Replies")]
        public int RepliesCount { get; set; }

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
