
// Manages the main conversation
// loop, reads and validates user input, handles special
// commands (quit, help)


using CybersecurityBot;
using System;

namespace CybersecurityBot
{
    /// <summary>
    /// Core chatbot class. Runs the interactive conversation loop,
    /// validates input, routes commands, and displays responses.
    public class ChatBot
    {

        /// <summary>
        /// The name of the current user. Personalises the conversation.
        public string UserName { get; private set; }

        /// <summary>
        /// Indicates whether the chat loop is currently active.
        /// Set to false when the user types a quit command.
        public bool IsRunning { get; private set; }


        // Handles all topic-based response lookups
        private readonly ResponseEngine _responseEngine;


        /// <summary>
        /// Initialises the chatbot with the given user name
        /// and creates a ResponseEngine instance for that user.
      
        public ChatBot(string userName)
        {
            UserName = userName;
            IsRunning = true;
            _responseEngine = new ResponseEngine(userName);
        }


        /// <summary>
        /// Starts and runs the main conversation loop.
        /// Continuously reads user input and processes it until
        /// the user types a quit command.
        public void StartChat()
        {
            // Prompt the user that the chat is ready
            DisplayHelper.TypeText(
                $"\n  Type your question below, {UserName}. (Type 'help' for topics or 'quit' to exit.)\n",
                ConsoleColor.Yellow);

            while (IsRunning)
            {
                // Display the input prompt with the user's name
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"   {UserName}: ");
                Console.ResetColor();

                // Read user input from the console
                string? rawInput = Console.ReadLine();

                // Step 1: Validate — reject empty or whitespace-only input
                if (!IsValidInput(rawInput))
                    continue;

                // Step 2: Process the validated input
                ProcessInput(rawInput!.Trim());
            }

            // Show the farewell message once the loop exits
            ShowFarewell();
        }


        /// <summary>
        /// Validates the raw input from the user.
        /// Returns false and prints a friendly warning for empty entries.
        /// Returns true if the input contains usable text.
        
        private bool IsValidInput(string? input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                DisplayHelper.PrintColoured(
                    "\n    I didn't catch anything. Please type a question or 'help' for options.",
                    ConsoleColor.Red);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Processes validated user input.
        /// Checks for special commands first (quit, help),
        
        private void ProcessInput(string input)
        {
            // Normalise to lowercase 
            string lower = input.ToLower();


            // Quit / exit command — stop the chat loop
            if (lower == "quit" || lower == "exit" || lower == "bye")
            {
                IsRunning = false;
                return;
            }

            // Help command — re-display the topics menu
            if (lower == "help" || lower.Contains("what can i ask"))
            {
                DisplayHelper.ShowTopicsMenu();
                return;
            }


            // Ask the ResponseEngine if it recognises any keyword in the input
            string? response = _responseEngine.GetResponse(input);

            if (response != null)
            {
                // A matching cybersecurity topic was found — display the response
                DisplayHelper.ShowBotResponse(response);
            }
            else
            {
                // No keyword matched
                // This handles invalid/unsupported queries 
                DisplayHelper.ShowBotResponse(
                    $"I didn't quite understand that, {UserName}. \n" +
                    "  Could you try rephrasing? Type 'help' to see the topics I can assist with.");
            }

            // Draw a divider after each exchange 
            DisplayHelper.PrintDivider('─');
        }

        /// <summary>
        /// Displays a personalised goodbye message when the user exits.
        /// Called once after the main loop ends.
        private void ShowFarewell()
        {
            Console.WriteLine();
            DisplayHelper.PrintDivider('═');
            DisplayHelper.TypeText(
                $"\n   Stay safe online, {UserName}! Goodbye and take care. \n",
                ConsoleColor.Green);
            DisplayHelper.PrintDivider('═');
            Console.WriteLine();
        }
    }
}