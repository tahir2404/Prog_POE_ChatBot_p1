using System;

namespace CybersecurityBotWPF.Tasks
{
    /// <summary>
    /// Represents a cybersecurity-related task created by the user. Stores task information such as title, description, reminder date and completion status.
    /// </summary>
    public class CyberTask
    {
        /// <summary>
        /// The unique task ID from the database.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The task title.
        /// </summary>
        public string Title { get; set; } = "";

        /// <summary>
        /// Additional task details or notes.
        /// </summary>
        public string Description { get; set; } = "";

        /// <summary>
        /// Optional reminder date for the task.
        /// </summary>
        public DateTime? ReminderDate { get; set; }

        /// <summary>
        /// Indicates whether the task has been completed.
        /// </summary>
        public bool IsCompleted { get; set; }

        /// <summary>
        /// Returns a formatted version of the task.
        /// </summary>
        public override string ToString()
        {
            string status = IsCompleted ? "Completed" : "Pending";
            string reminder = ReminderDate.HasValue
                ? ReminderDate.Value.ToString("yyyy-MM-dd HH:mm")
                : "No reminder set";

            return $"Task ID: {Id}\n" +
                   $"Task: {Title}\n" +
                   $"Description: {Description}\n" +
                   $"Reminder: {reminder}\n" +
                   $"Status: {status}";
        }
    }
}