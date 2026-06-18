using CybersecurityBotWPF.Quiz;
using CybersecurityBotWPF.Tasks;

namespace CybersecurityBotWPF
{
    /// <summary>
    /// Handles the main chatbot logic for the WPF application.
    /// This class receives user input from the GUI and returns chatbot responses.
    /// </summary>
    public class ChatBot
    {
        private readonly string _userName;
        private readonly ResponseEngine _responseEngine;
        private readonly UserMemory _memory;
        private readonly SentimentDetector _sentimentDetector;
        private readonly TaskManager _taskManager;
        private readonly QuizManager _quizManager;
        private readonly ActivityLog _activityLog;
        private readonly NlpProcessor _nlpProcessor;

        /// <summary>
        /// Creates a new chatbot instance and prepares all helper classes.
        /// </summary>
        public ChatBot(string userName)
        {
            _userName = userName;
            _responseEngine = new ResponseEngine(userName);
            _memory = new UserMemory();
            _sentimentDetector = new SentimentDetector();
            _taskManager = new TaskManager();
            _quizManager = new QuizManager();
            _activityLog = new ActivityLog();
            _nlpProcessor = new NlpProcessor();
        }

        /// <summary>
        /// Processes the user's message and returns an appropriate chatbot response.
        /// </summary>
        public string GetBotResponse(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return "Please type a question or message.";
            }

            string lowerInput = input.ToLower();
            string intent = _nlpProcessor.DetectIntent(input);

            if (lowerInput == "help" || lowerInput.Contains("what can i ask"))
            {
                return GetHelpMessage();
            }

            if (lowerInput == "quit" || lowerInput == "exit" || lowerInput == "bye")
            {
                return $"Goodbye, {_userName}. Stay safe online!";
            }

            if (intent == "activity_log")
            {
                return _activityLog.GetRecentActions();
            }

            if (_quizManager.IsQuizActive)
            {
                _activityLog.AddAction("Quiz answer submitted");
                return _quizManager.SubmitAnswer(input);
            }

            if (intent == "start_quiz")
            {
                _activityLog.AddAction("Cybersecurity quiz started");
                return _quizManager.StartQuiz();
            }

            if (intent == "add_task")
            {
                string taskTitle = input
                    .Replace("add task", "", System.StringComparison.OrdinalIgnoreCase)
                    .Replace("create task", "", System.StringComparison.OrdinalIgnoreCase)
                    .Replace("remind me", "", System.StringComparison.OrdinalIgnoreCase)
                    .Replace("to", "", System.StringComparison.OrdinalIgnoreCase)
                    .Trim();

                if (string.IsNullOrWhiteSpace(taskTitle))
                {
                    return "Please tell me what task you want to add.";
                }

                CyberTask newTask = new CyberTask
                {
                    Title = taskTitle,
                    Description = $"Cybersecurity task: {taskTitle}",
                    IsCompleted = false
                };

                _taskManager.AddTask(newTask);
                _activityLog.AddAction($"Task added: {taskTitle}");

                return $"Task added: {taskTitle}";
            }

            if (intent == "show_tasks")
            {
                var tasks = _taskManager.GetTasks();

                if (tasks.Count == 0)
                {
                    return "You do not have any cybersecurity tasks yet.";
                }

                string taskList = "Here are your cybersecurity tasks:\n\n";

                foreach (CyberTask task in tasks)
                {
                    taskList += task.ToString() + "\n\n";
                }

                return taskList;
            }

            if (intent == "complete_task")
            {
                string taskTitle = input
                    .Replace("complete task", "", System.StringComparison.OrdinalIgnoreCase)
                    .Trim();

                if (string.IsNullOrWhiteSpace(taskTitle))
                {
                    return "Please tell me which task you want to complete.";
                }

                bool completed = _taskManager.CompleteTask(taskTitle);

                if (completed)
                {
                    _activityLog.AddAction($"Task completed: {taskTitle}");
                    return $"Task completed: {taskTitle}";
                }

                return $"I could not find a task called: {taskTitle}";
            }

            if (intent == "delete_task")
            {
                string taskTitle = input
                    .Replace("delete task", "", System.StringComparison.OrdinalIgnoreCase)
                    .Trim();

                if (string.IsNullOrWhiteSpace(taskTitle))
                {
                    return "Please tell me which task you want to delete.";
                }

                bool deleted = _taskManager.DeleteTask(taskTitle);

                if (deleted)
                {
                    _activityLog.AddAction($"Task deleted: {taskTitle}");
                    return $"Task deleted: {taskTitle}";
                }

                return $"I could not find a task called: {taskTitle}";
            }

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

                if (lowerInput.Contains("scam"))
                {
                    _memory.FavouriteTopic = "scams";
                    return "Got it! I'll remember that scam awareness interests you.";
                }
            }

            string sentiment = _sentimentDetector.DetectSentiment(input);

            if (sentiment == "worried")
            {
                return "It's completely understandable to feel worried about cybersecurity threats.\n\n" +
                       "A good first step is to avoid clicking suspicious links and never share passwords, PINs, or OTPs with anyone.";
            }

            if (sentiment == "frustrated")
            {
                return "Cybersecurity can definitely feel overwhelming sometimes, but you're doing the right thing by learning about it.\n\n" +
                       "Focus on simple habits like strong passwords, safe browsing, and checking links before clicking.";
            }

            if (sentiment == "curious")
            {
                return "I love your curiosity about cybersecurity! Learning about online safety is one of the best ways to protect yourself.";
            }

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

            string? response = _responseEngine.GetResponse(input);

            if (response != null)
            {
                if (lowerInput.Contains("password"))
                    _memory.LastTopic = "password";
                else if (lowerInput.Contains("phishing"))
                    _memory.LastTopic = "phishing";
                else if (lowerInput.Contains("scam"))
                    _memory.LastTopic = "scam";
                else if (lowerInput.Contains("privacy"))
                    _memory.LastTopic = "privacy";
                else if (lowerInput.Contains("malware"))
                    _memory.LastTopic = "malware";
                else if (lowerInput.Contains("social"))
                    _memory.LastTopic = "social engineering";
                else if (lowerInput.Contains("browsing"))
                    _memory.LastTopic = "safe browsing";

                if (!string.IsNullOrWhiteSpace(_memory.FavouriteTopic))
                {
                    response += $"\n\nSince you're interested in {_memory.FavouriteTopic}, this topic is especially important for you.";
                }

                return response;
            }

            return $"I'm not sure I understand, {_userName}. Can you try rephrasing? Type 'help' to see what you can ask me.";
        }

        /// <summary>
        /// Returns the list of cybersecurity topics and commands the chatbot can help with.
        /// </summary>
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
                "Task commands:\n" +
                "• add task to update my password\n" +
                "• remind me to update my password\n" +
                "• create task to enable two-factor authentication\n" +
                "• show my tasks\n" +
                "• complete task update my password\n" +
                "• delete task update my password\n\n" +
                "Quiz commands:\n" +
                "• start quiz\n" +
                "• play game\n\n" +
                "Activity log commands:\n" +
                "• show activity log\n" +
                "• what have you done for me\n\n" +
                "You can also say 'tell me more' or 'another tip'.";
        }
    }
}