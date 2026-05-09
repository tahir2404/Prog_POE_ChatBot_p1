using CybersecurityBot;

namespace CybersecurityBotWPF
{
    /// <summary>
    /// Handles the main chatbot logic for the WPF application.
    /// This class receives user input from the GUI and returns chatbot responses.
    /// </summary>
    public class ChatBot
    {
        // Stores the user's name for personalised responses
        private string _userName;

        // Handles keyword-based cybersecurity responses
        private readonly ResponseEngine _responseEngine;

        /// <summary>
        /// Creates a new chatbot instance and prepares the response engine.
        /// </summary>
        /// <param name="userName">The name of the current user.</param>
        public ChatBot(string userName)
        {
            _userName = userName;
            _responseEngine = new ResponseEngine(userName);
        }

        /// <summary>
        /// Processes the user's message and returns an appropriate chatbot response.
        /// This replaces the old console-based StartChat method.
        /// </summary>
        /// <param name="input">The message entered by the user.</param>
        /// <returns>A chatbot response as text.</returns>
        public string GetBotResponse(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return "Please type a question or message.";
            }

            string lowerInput = input.ToLower();

            if (lowerInput == "help" || lowerInput.Contains("what can i ask"))
            {
                return GetHelpMessage();
            }

            if (lowerInput == "quit" || lowerInput == "exit" || lowerInput == "bye")
            {
                return $"Goodbye, {_userName}. Stay safe online!";
            }

            string? response = _responseEngine.GetResponse(input);

            if (response != null)
            {
                return response;
            }

            return $"I'm not sure I understand, {_userName}. Can you try rephrasing? Type 'help' to see what you can ask me.";
        }

        /// <summary>
        /// Returns the list of cybersecurity topics the chatbot can help with.
        /// </summary>
        /// <returns>A formatted help message with available topics.</returns>
        private string GetHelpMessage()
        {
            return
                "You can ask me about:\n\n" +
                "• password safety\n" +
                "• phishing scams\n" +
                "• scam awareness\n" +
                "• safe browsing\n" +
                "• malware\n" +
                "• social engineering\n" +
                "• online privacy\n\n" +
                "You can also say things like 'tell me more' or 'give me another tip'.";
        }
    }
}