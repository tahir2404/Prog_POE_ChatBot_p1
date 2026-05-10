namespace CybersecurityBotWPF
{
    /// <summary>
    /// Detects basic user sentiment from chatbot messages. Used to make responses feel more natural and empathetic.
    /// </summary>
    public class SentimentDetector
    {
        /// <summary>
        /// Detects the emotional tone of the user's message.
        /// </summary>
        public string DetectSentiment(string input)
        {
            string lowerInput = input.ToLower();

            if (lowerInput.Contains("worried") ||
                lowerInput.Contains("scared") ||
                lowerInput.Contains("nervous"))
            {
                return "worried";
            }

            if (lowerInput.Contains("frustrated") ||
                lowerInput.Contains("angry") ||
                lowerInput.Contains("annoyed"))
            {
                return "frustrated";
            }

            if (lowerInput.Contains("curious") ||
                lowerInput.Contains("interested"))
            {
                return "curious";
            }

            return "neutral";
        }
    }
}