// Entry point for the Cybersecurity Awareness Chatbot.
// it simply coordinates the startup sequence 

namespace CybersecurityBot
{
    class Program
    {
        static void Main(string[] args)
        {
            // Step 1: Play the recorded WAV voice greeting
            AudioHelper.PlayGreeting();

            // Step 2: Display the ASCII art logo/title screen
            DisplayHelper.ShowLogo();

            // Step 3: Ask for the user's name and show a welcome message
            string userName = DisplayHelper.GreetUser();

            // Step 4: Create the chatbot and start the conversation loop
            ChatBot bot = new ChatBot(userName);
            bot.StartChat();
        }
    }
}