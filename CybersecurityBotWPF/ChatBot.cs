using CybersecurityBotWPF;

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

        private readonly UserMemory _memory;

        private readonly SentimentDetector _sentimentDetector;

        /// <summary>
        /// Creates a new chatbot instance and prepares the response engine.
        /// </summary>
        /// <param name="userName">The name of the current user.</param>
        public ChatBot(string userName)
        {
            _userName = userName;
            _responseEngine = new ResponseEngine(userName);
            _memory = new UserMemory();
            _sentimentDetector = new SentimentDetector();
        }

        /// <summary>
        /// Processes the user's message and returns an appropriate chatbot response.
        /// This replaces the old console-based StartChat method.
        /// </summary>
        /// <param name="input">The message entered by the user.</param>
        /// <returns>A chatbot response as text.</returns>
        public string GetBotResponse(string input)
        {
            // Prevent empty input
            if (string.IsNullOrWhiteSpace(input))
            {
                return "Please type a question or message.";
            }

            // Convert input to lowercase for easier keyword matching
            string lowerInput = input.ToLower();

            // Show help menu
            if (lowerInput == "help" || lowerInput.Contains("what can i ask"))
            {
                return GetHelpMessage();
            }

            // Exit chatbot message
            if (lowerInput == "quit" || lowerInput == "exit" || lowerInput == "bye")
            {
                return $"Goodbye, {_userName}. Stay safe online!";
            }

            // Remember favourite topics
            if (lowerInput.Contains("interested in"))
            {
                if (lowerInput.Contains("privacy"))
                {
                    _memory.FavouriteTopic = "privacy";
                    return "Great! I'll remember that you're interested in privacy.";
                }

                if (lowerInput.Contains("password"))
                {
                    _memory.FavouriteTopic = "password safety";
                    return "Awesome! I'll remember that you're interested in password safety.";
                }

                if (lowerInput.Contains("phishing"))
                {
                    _memory.FavouriteTopic = "phishing";
                    return "Got it! I'll remember that phishing awareness interests you.";
                }
            }

            // Detect sentiment
            string sentiment = _sentimentDetector.DetectSentiment(input);

            // Worried response
            if (sentiment == "worried")
            {
                return "It's completely understandable to feel worried about cybersecurity threats.\n\n" +
                       "A good first step is to avoid clicking suspicious links and never share passwords with anyone.";
            }

            // Frustrated response
            if (sentiment == "frustrated")
            {
                return "Cybersecurity can definitely feel overwhelming sometimes, but you're doing the right thing by learning about it.\n\n" +
                       "Focus on simple habits like strong passwords and safe browsing.";
            }

            // Curious response
            if (sentiment == "curious")
            {
                return "I love your curiosity about cybersecurity! Learning about online safety is one of the best ways to protect yourself.";
            }

            // Handle follow-up conversation flow
            if (lowerInput.Contains("tell me more") ||
                lowerInput.Contains("another tip") ||
                lowerInput.Contains("explain more"))
            {
                if (!string.IsNullOrWhiteSpace(_memory.LastTopic))
                {
                    return $"Here is another important {_memory.LastTopic} tip:\n\n" +
                           _responseEngine.GetResponse(_memory.LastTopic);
                }

                return "Please ask about a cybersecurity topic first so I know what you'd like to learn more about.";
            }

            // Get normal cybersecurity response
            string? response = _responseEngine.GetResponse(input);

            // If a keyword response exists
            if (response != null)
            {
                // Add personalised memory message
                if (!string.IsNullOrWhiteSpace(_memory.FavouriteTopic))
                {
                    response += $"\n\nSince you're interested in {_memory.FavouriteTopic}, this topic is especially important for you.";
                }

                // Remember the last topic discussed
                if (lowerInput.Contains("password"))
                {
                    _memory.LastTopic = "password";
                }
                else if (lowerInput.Contains("phishing"))
                {
                    _memory.LastTopic = "phishing";
                }
                else if (lowerInput.Contains("scam"))
                {
                    _memory.LastTopic = "scam";
                }
                else if (lowerInput.Contains("privacy"))
                {
                    _memory.LastTopic = "privacy";
                }
                else if (lowerInput.Contains("malware"))
                {
                    _memory.LastTopic = "malware";
                }
                else if (lowerInput.Contains("social"))
                {
                    _memory.LastTopic = "social engineering";
                }

                return response;
            }

            // Default fallback response
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