using System;
using System.Collections.Generic;
using System.Linq;

namespace CybersecurityBotWPF
{
    /// <summary>
    /// Stores recent chatbot actions so the user can view
    /// what the chatbot has done during the session.
    /// </summary>
    public class ActivityLog
    {
        private readonly List<string> _actions = new();

        /// <summary>
        /// Adds a new action to the activity log with a timestamp.
        /// </summary>
        public void AddAction(string action)
        {
            string entry = $"{DateTime.Now:HH:mm} - {action}";
            _actions.Add(entry);
        }

        /// <summary>
        /// Returns the most recent chatbot actions.
        /// </summary>
        public string GetRecentActions()
        {
            if (_actions.Count == 0)
            {
                return "No recent activity has been recorded yet.";
            }

            List<string> recentActions = _actions.TakeLast(10).ToList();

            string result = "Here’s a summary of recent actions:\n\n";

            for (int i = 0; i < recentActions.Count; i++)
            {
                result += $"{i + 1}. {recentActions[i]}\n";
            }

            return result;
        }
    }
}