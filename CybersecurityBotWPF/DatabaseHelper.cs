using MySql.Data.MySqlClient;

namespace CybersecurityBotWPF
{
    /// <summary>
    /// Handles database connectivity for the chatbot.
    /// </summary>
    public static class DatabaseHelper
    {
        private const string ConnectionString =
            "server=localhost;" +
            "database=CybersecurityBotDB;" +
            "uid=root;" +
            "pwd=Fortnite2404;";

        /// <summary>
        /// Creates and opens a MySQL database connection.
        /// </summary>
        /// <returns>An open MySqlConnection object.</returns>
        public static MySqlConnection GetConnection()
        {
            MySqlConnection connection = new MySqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }
    }
}