namespace CybersecurityBotWPF
{
    /// <summary>
    /// Manages the chatbot conversation state and follow-up flow. Stores the most recent cybersecurity topic discussed.
    /// </summary>
    public class ConversationManager
    {
        /// <summary>
        /// Stores the last cybersecurity topic discussed.
        /// </summary>
        public string CurrentTopic { get; set; } = "";
    }
}