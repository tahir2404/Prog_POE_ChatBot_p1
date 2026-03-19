using System;

namespace CybersecurityBot
{
    
    class Program
    {
        static void Main(string[] args)
        {
            // Play the voice greeting when the app launches
            AudioHelper.PlayGreeting();

            // Display the ASCII art logo/header
            DisplayHelper.ShowLogo();

            // Get the user's name and personalise the session
            string userName = DisplayHelper.GreetUser();

            // Start the main chat loop
            ChatBot bot = new ChatBot(userName);
            bot.StartChat();
        }
    }
}