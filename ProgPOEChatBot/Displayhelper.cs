// Handles everything visual in the console:
//   - ASCII art logo displayed on startup
//   - Coloured text output
//   - Typing animation effect
//   - Divider lines for structure
//   - User name prompt and welcome message
//   - Topics menu
//   - Bot response formatting


using System;
using System.Threading;

namespace CybersecurityBot
{
    /// <summary>
    /// Static helper class responsible for all console display and formatting.
    public static class DisplayHelper
    {
        // Controls the width of divider lines throughout the UI
        private const int DividerWidth = 62;


        /// <summary>
        /// Clears the console and displays the ASCII art logo along with
        /// the application title. Called once on startup after the voice greeting.
        public static void ShowLogo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine(@"
  ╔══════════════════════════════════════════════════════════╗
  ║                                                          ║
  ║     /$$$$$$  /$$     /$$ /$$$$$$$  /$$$$$$$$ /$$$$$$$    ║
  ║    /$$__  $$|  $$   /$$/| $$__  $$| $$_____/| $$__  $$   ║
  ║   | $$  \__/ \  $$ /$$/ | $$  \ $$| $$      | $$  \ $$   ║
  ║   | $$        \  $$$$/  | $$$$$$$ | $$$$$   | $$$$$$$/   ║
  ║   | $$         \  $$/   | $$__  $$| $$__/   | $$__  $$   ║
  ║   | $$    $$    | $$    | $$  \ $$| $$      | $$  \ $$   ║
  ║   |  $$$$$$/    | $$    | $$$$$$$/| $$$$$$$$| $$  | $$   ║
  ║    \______/     |__/    |_______/ |________/|__/  |__/   ║
  ║                                                          ║
  ║           CYBERSECURITY AWARENESS ASSISTANT              ║
  ║             Protecting South African Citizens            ║
  ║                                                          ║
  ╚══════════════════════════════════════════════════════════╝
");
            PrintDivider('═');
            Console.ResetColor();
        }


        /// <summary>
        /// Prompts the user to enter their name, validates the input,
        /// then displays a personalised welcome message.
        /// Loops until a valid non-empty name is provided.
        /// Returns the entered name so other classes can use it.
        public static string GreetUser()
        {
            string userName = string.Empty;

            // Keep asking until a proper name is entered
            while (string.IsNullOrWhiteSpace(userName))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\n   Please enter your name: ");
                Console.ResetColor();

                userName = Console.ReadLine()?.Trim() ?? string.Empty;

                if (string.IsNullOrWhiteSpace(userName))
                {
                    // Inform the user and loop again
                    PrintColoured("    Name cannot be empty. Please try again.", ConsoleColor.Red);
                }
            }

            // Show a personalised welcome with a typing animation
            Console.WriteLine();
            PrintDivider('─');
            TypeText($"\n   Welcome, {userName}!", ConsoleColor.Green);
            TypeText("  I'm your Cybersecurity Awareness Assistant.", ConsoleColor.Green);
            TypeText("  I'm here to help you stay safe online in South Africa and beyond.\n", ConsoleColor.Green);
            PrintDivider('─');

            // Show the topics menu right after the greeting
            ShowTopicsMenu();

            return userName;
        }


        /// <summary>
        /// Displays the list of available cybersecurity topics the user can ask about.
        /// Also shown when the user types "help".
        public static void ShowTopicsMenu()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n   Topics you can ask me about:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  ┌─────────────────────────────────────────────────┐");
            Console.WriteLine("  │  • password    – Password safety tips           │");
            Console.WriteLine("  │  • phishing    – How to spot phishing scams     │");
            Console.WriteLine("  │  • browsing    – Safe browsing habits           │");
            Console.WriteLine("  │  • malware     – Malware awareness              │");
            Console.WriteLine("  │  • social      – Social engineering threats     │");
            Console.WriteLine("  │  • privacy     – Protecting your personal info  │");
            Console.WriteLine("  │  • how are you – Chat with me                   │");
            Console.WriteLine("  │  • purpose     – What I do                      │");
            Console.WriteLine("  │  • help        – Show this menu again           │");
            Console.WriteLine("  │  • quit        – Exit the chatbot               │");
            Console.WriteLine("  └─────────────────────────────────────────────────┘");
            Console.ResetColor();
            PrintDivider('─');
        }


        /// <summary>
        /// Prints a full-width horizontal divider line using the given character.
        
        public static void PrintDivider(char character)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("  " + new string(character, DividerWidth));
            Console.ResetColor();
        }

        /// <summary>
        /// Prints a line of text in the specified colour,
        /// then resets the console colour back to default.
        public static void PrintColoured(string message, ConsoleColor colour)
        {
            Console.ForegroundColor = colour;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Simulates a typing effect by printing one character at a time
        /// with a short delay between each.
        public static void TypeText(string message, ConsoleColor colour, int delayMs = 15)
        {
            Console.ForegroundColor = colour;
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(delayMs); // Small pause between characters
            }
            Console.WriteLine();
            Console.ResetColor();
        }


        /// <summary>
        /// Displays a formatted bot response with a consistent label prefix.
       
        public static void ShowBotResponse(string response)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("   Bot: ");
            TypeText(response, ConsoleColor.White, 10);
            Console.WriteLine();
        }
    }
}