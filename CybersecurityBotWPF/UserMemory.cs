namespace CybersecurityBotWPF
{
    /// <summary>
    /// Stores information the chatbot remembers about the user. Used to personalise chatbot conversations.
    /// </summary>
    public class UserMemory
    {
        /// <summary>
        /// Stores the user's favourite cybersecurity topic.
        /// </summary>
        public string FavouriteTopic { get; set; } = "";

        /// <summary>
        /// Stores the last cybersecurity topic discussed. Used for follow-up conversation flow.
        /// </summary>
        public string LastTopic { get; set; } = "";
    }
}