namespace CybersecurityBotWPF
{
    /// <summary>
    /// Simulates basic Natural Language Processing (NLP) by identifying the user's intended action from different sentence patterns.
    /// </summary>
    public class NlpProcessor
    {
        /// <summary>
        /// Determines the user's intended command.
        /// </summary>
        /// <returns>The detected intent.</returns>
        public string DetectIntent(string input)
        {
            string lowerInput = input.ToLower();


            if (lowerInput.Contains("remind me on") ||
            lowerInput.Contains("set reminder"))
            {
                return "set_reminder";
            }

            // Task intents
            if (lowerInput.Contains("add task") ||
                lowerInput.Contains("remind me") ||
                lowerInput.Contains("create task"))
            {
                return "add_task";
            }

            if (lowerInput.Contains("show tasks") ||
                lowerInput.Contains("show my tasks") ||
                lowerInput.Contains("view tasks"))
            {
                return "show_tasks";
            }

            if (lowerInput.Contains("complete task"))
            {
                return "complete_task";
            }

            if (lowerInput.Contains("delete task"))
            {
                return "delete_task";
            }

            // Quiz intents
            if (lowerInput.Contains("start quiz") ||
                lowerInput.Contains("play game") ||
                lowerInput.Contains("quiz"))
            {
                return "start_quiz";
            }

            // Activity log intents
            if (lowerInput.Contains("activity log") ||
                lowerInput.Contains("what have you done"))
            {
                return "activity_log";
            }

            return "general_chat";
        }
    }
}