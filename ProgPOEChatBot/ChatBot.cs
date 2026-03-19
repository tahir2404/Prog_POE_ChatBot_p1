using System;
using System.Collections.Generic;
using System.Text;

namespace CybersecurityBot
{
        /// The core chatbot class that manages the main conversation loop.
        /// It reads user input, validates it, and delegates response generation
        /// to the ResponseEngine. It also handles special commands like 'help' and 'quit'.
        public class ChatBot
        {
            // The user's name — used to personalise responses
            private readonly string _userName;

            // The engine that holds all the predefined cybersecurity responses
            private readonly ResponseEngine _responseEngine;

            // Tracks whether the chat loop should keep running
            private bool _isRunning;

            /// Constructor — sets up the chatbot with the user's name
            /// and creates a new ResponseEngine instance.
            public ChatBot(string userName)
            {
                _userName = userName;
                _responseEngine = new ResponseEngine(userName);
                _isRunning = true;
            }

            /// Starts and manages the main chat loop.
            /// Continuously reads user input and processes it until the user types 'quit'.
            public void StartChat()
            {
                DisplayHelper.TypeText(
                    $"\n  Type your question below, {_userName}. Type 'quit' to exit.\n",
                    ConsoleColor.Yellow);

                while (_isRunning)
                {
                    // Show the user input prompt
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"  👤 {_userName}: ");
                    Console.ResetColor();

                    // Read the user's message
                    string input = Console.ReadLine();

                    // Validate the input before doing anything with it
                    if (!IsValidInput(input))
                        continue;

                    // Process the validated input
                    ProcessInput(input.Trim());
                }

                // Show a farewell message when the user exits
                ShowFarewell();
            }

            /// Validates user input to catch empty strings or whitespace-only entries.
            /// Prints a friendly error message for invalid input and returns false.
            /// Returns true if the input is usable.
            private bool IsValidInput(string input)
            {
                if (string.IsNullOrWhiteSpace(input))
                {
                    DisplayHelper.PrintColoured(
                        "  ⚠  I didn't catch that. Could you type something? (Type 'help' for options.)",
                        ConsoleColor.Red);
                    return false;
                }

                return true;
            }

            /// Processes the validated user input.
            /// Handles special commands ('quit', 'help') directly,
            /// then delegates to the ResponseEngine for topic-based responses.
            /// Shows a default fallback message for unrecognised queries.
            private void ProcessInput(string input)
            {
                string lowerInput = input.ToLower();

                // Handle special commands 

                // Exit command
                if (lowerInput == "quit" || lowerInput == "exit" || lowerInput == "bye")
                {
                    _isRunning = false;
                    return;
                }

                // Help command — re-display the topic menu
                if (lowerInput == "help" || lowerInput.Contains("what can i ask"))
                {
                    DisplayHelper.ShowTopicsMenu();
                    return;
                }

                // Look up a response from the ResponseEngine 
                string response = _responseEngine.GetResponse(input);

                if (response != null)
                {
                    // A matching keyword was found — display the response
                    DisplayHelper.ShowBotResponse(response);
                }
                else
                {
                    // No matching keyword — show a graceful fallback message
                    DisplayHelper.ShowBotResponse(
                        $"I didn't quite understand that, {_userName}. 🤔\n" +
                        "  Could you rephrase, or type 'help' to see the topics I can assist with?");
                }

                // Draw a divider after each response for readability
                DisplayHelper.PrintDivider('─');
            }

            /// Displays a personalised goodbye message when the user exits the chatbot.
            private void ShowFarewell()
            {
                Console.WriteLine();
                DisplayHelper.PrintDivider('═');
                DisplayHelper.TypeText(
                    $"\n  👋 Stay safe online, {_userName}! Goodbye and take care. 🔒\n",
                    ConsoleColor.Green);
                DisplayHelper.PrintDivider('═');
                Console.WriteLine();
            }
        }
    }

