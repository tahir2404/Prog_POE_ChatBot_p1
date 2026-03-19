using System;
using System.Threading;

namespace CybersecurityBot
{
    /// Handles all console display logic including the ASCII logo,
    /// coloured text output, typing effects, dividers, and user greeting.
    public static class DisplayHelper
    {
        // Width used for divider lines throughout the UI
        private const int DividerWidth = 60;

        /// Displays the ASCII art logo and application title on startup.
        /// Uses cyan colour for a techy, cybersecurity feel.
        public static void ShowLogo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;

            // ASCII art logo — cybersecurity themed with border
            Console.WriteLine(@"
  ╔══════════════════════════════════════════════════════════╗
  ║                                                          ║
  ║     /$$$$$$  /$$     /$$ /$$$$$$$  /$$$$$$$$ /$$$$$$$   ║
  ║    /$$__  $$|  $$   /$$/| $$__  $$| $$_____/| $$__  $$  ║
  ║   | $$  \__/ \  $$ /$$/ | $$  \ $$| $$      | $$  \ $$  ║
  ║   | $$        \  $$$$/  | $$$$$$$ | $$$$$   | $$$$$$$/  ║
  ║   | $$         \  $$/   | $$__  $$| $$__/   | $$__  $$  ║
  ║   | $$    $$    | $$    | $$  \ $$| $$      | $$  \ $$  ║
  ║   |  $$$$$$/    | $$    | $$$$$$$/| $$$$$$$$| $$  | $$  ║
  ║    \______/     |__/    |_______/ |________/|__/  |__/  ║
  ║                                                          ║
  ║            CYBERSECURITY AWARENESS ASSISTANT             ║
  ║              Protecting South African Citizens           ║
  ║                                                          ║
  ╚══════════════════════════════════════════════════════════╝
");

            // Draw a decorative top border
            PrintDivider('═');
            Console.ResetColor();
        }

        /// Asks the user for their name and displays a personalised welcome message.
        /// Loops until a valid (non-empty) name is entered.
        /// Returns the entered name for use throughout the session.
        public static string GreetUser()
        {
            string userName = string.Empty;

            // Keep asking until a valid name is given
            while (string.IsNullOrWhiteSpace(userName))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\n  👤 Please enter your name: ");
                Console.ResetColor();

                userName = Console.ReadLine()?.Trim();

                // Handle empty/whitespace input
                if (string.IsNullOrWhiteSpace(userName))
                {
                    PrintColoured("  ⚠  Name cannot be empty. Please try again.", ConsoleColor.Red);
                }
            }

            // Display the personalised welcome with a typing effect
            Console.WriteLine();
            PrintDivider('─');
            TypeText($"\n  👋 Welcome, {userName}! I'm your Cybersecurity Awareness Assistant.", ConsoleColor.Green);
            TypeText("  I'm here to help you stay safe online in South Africa and beyond.\n", ConsoleColor.Green);
            PrintDivider('─');

            // Show a quick menu of available topics
            ShowTopicsMenu();

            return userName;
        }

        /// Prints a quick reference menu showing what topics the chatbot covers.
        public static void ShowTopicsMenu()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n  📋 You can ask me about:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("     • password       – Password safety tips");
            Console.WriteLine("     • phishing        – How to spot phishing scams");
            Console.WriteLine("     • browsing        – Safe browsing habits");
            Console.WriteLine("     • malware         – What malware is and how to avoid it");
            Console.WriteLine("     • social          – Social engineering awareness");
            Console.WriteLine("     • privacy         – Protecting your personal information");
            Console.WriteLine("     • how are you     – Chat with me!");
            Console.WriteLine("     • purpose         – Learn what I do");
            Console.WriteLine("     • help            – Show this menu again");
            Console.WriteLine("     • quit            – Exit the chatbot");
            PrintDivider('─');
            Console.ResetColor();
        }

        /// Prints a full-width divider line using the given character.
        /// Useful for visually separating sections in the console UI.
        public static void PrintDivider(char character)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("  " + new string(character, DividerWidth));
            Console.ResetColor();
        }

        /// Prints a single line of text in a specified colour,
        /// then resets the console colour back to default.
        public static void PrintColoured(string message, ConsoleColor colour)
        {
            Console.ForegroundColor = colour;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// Simulates a typing effect by printing each character with a small delay.
        /// Makes the chatbot feel more conversational and human-like.
        public static void TypeText(string message, ConsoleColor colour, int delayMs = 18)
        {
            Console.ForegroundColor = colour;
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(delayMs); // Short pause between each character
            }
            Console.WriteLine(); // New line after the message is done
            Console.ResetColor();
        }

        /// Displays the chatbot's response with consistent formatting:
        /// a bot label prefix and green coloured text.
        public static void ShowBotResponse(string response)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("  🤖 Bot: ");
            TypeText(response, ConsoleColor.White, 12);
            Console.WriteLine();
        }
    }
}