using MySql.Data.MySqlClient;

namespace TweetsModels {
    class Database {
        public static MySqlConnection GetConnection() {
            string connectionString = @"
                server=localhost;
                user id=etec_aspnet_tweets;
                password=12345678;
                database=etec_aspnet_tweets;
            ";
            return new MySqlConnection(connectionString);
        }
    }
}
