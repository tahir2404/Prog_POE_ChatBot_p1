using System.Collections.Generic;
using System.Linq;

namespace CybersecurityBotWPF.Tasks
{
    /// <summary>
    /// Manages the user's cybersecurity tasks.
    /// Handles adding, retrieving, completing,
    /// and deleting tasks.
    /// </summary>
    public class TaskManager
    {
        // Stores all created tasks
        private readonly List<CyberTask> _tasks = new();

        /// <summary>
        /// Adds a new task to the task list.
        /// </summary>
        public void AddTask(CyberTask task)
        {
            _tasks.Add(task);
        }

        /// <summary>
        /// Returns all stored tasks.
        /// </summary>
        public List<CyberTask> GetTasks()
        {
            return _tasks;
        }

        /// <summary>
        /// Marks a task as completed using its title.
        /// </summary>
        public bool CompleteTask(string title)
        {
            CyberTask? task = _tasks.FirstOrDefault(
                t => t.Title.ToLower() == title.ToLower());

            if (task != null)
            {
                task.IsCompleted = true;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Deletes a task using its title.
        /// </summary>
        public bool DeleteTask(string title)
        {
            CyberTask? task = _tasks.FirstOrDefault(
                t => t.Title.ToLower() == title.ToLower());

            if (task != null)
            {
                _tasks.Remove(task);
                return true;
            }

            return false;
        }
    }
}