using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CybersecurityBotWPF.Tasks
{
    /// <summary>
    /// Manages the user's cybersecurity tasks.
    /// Handles adding, retrieving, completing,
    /// and deleting tasks using the MySQL database.
    /// </summary>
    public class TaskManager
    {
        /// <summary>
        /// Adds a new task to the MySQL database.
        /// </summary>
        public void AddTask(CyberTask task)
        {
            using MySqlConnection connection = DatabaseHelper.GetConnection();

            string query =
                "INSERT INTO Tasks (Title, Description, ReminderDate, IsCompleted) " +
                "VALUES (@Title, @Description, @ReminderDate, @IsCompleted)";

            using MySqlCommand command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("@Title", task.Title);
            command.Parameters.AddWithValue("@Description", task.Description);
            command.Parameters.AddWithValue("@ReminderDate",
                task.ReminderDate.HasValue ? task.ReminderDate.Value : DBNull.Value);
            command.Parameters.AddWithValue("@IsCompleted", task.IsCompleted);

            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Retrieves all tasks from the MySQL database.
        /// </summary>
        public List<CyberTask> GetTasks()
        {
            List<CyberTask> tasks = new List<CyberTask>();

            using MySqlConnection connection = DatabaseHelper.GetConnection();

            string query = "SELECT Id, Title, Description, ReminderDate, IsCompleted FROM Tasks";

            using MySqlCommand command = new MySqlCommand(query, connection);
            using MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                CyberTask task = new CyberTask
                {
                    Id = reader.GetInt32("Id"),
                    Title = reader.GetString("Title"),
                    Description = reader["Description"]?.ToString() ?? "",
                    ReminderDate = reader["ReminderDate"] == DBNull.Value
                        ? null
                        : Convert.ToDateTime(reader["ReminderDate"]),
                    IsCompleted = Convert.ToBoolean(reader["IsCompleted"])
                };

                tasks.Add(task);
            }

            return tasks;
        }

        /// <summary>
        /// Returns all overdue or due-today tasks.
        /// </summary>
        public List<CyberTask> GetDueTasks()
        {
            List<CyberTask> dueTasks = new();

            foreach (CyberTask task in GetTasks())
            {
                if (task.ReminderDate.HasValue &&
                    task.ReminderDate.Value.Date <= DateTime.Today &&
                    !task.IsCompleted)
                {
                    dueTasks.Add(task);
                }
            }

            return dueTasks;
        }

        /// <summary>
        /// Marks a task as completed in the MySQL database using its title.
        /// </summary>
        public bool CompleteTask(string title)
        {
            using MySqlConnection connection = DatabaseHelper.GetConnection();

            string query =
                "UPDATE Tasks SET IsCompleted = TRUE " +
                "WHERE LOWER(Title) = LOWER(@Title)";

            using MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Title", title);

            int rowsAffected = command.ExecuteNonQuery();

            return rowsAffected > 0;
        }

        /// <summary>
        /// Deletes a task from the MySQL database using its title.
        /// </summary>
        public bool DeleteTask(string title)
        {
            using MySqlConnection connection = DatabaseHelper.GetConnection();

            string query =
                "DELETE FROM Tasks WHERE LOWER(Title) = LOWER(@Title)";

            using MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@Title", title);

            int rowsAffected = command.ExecuteNonQuery();

            return rowsAffected > 0;
        }

    }
}