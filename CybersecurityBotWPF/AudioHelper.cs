
// Responsible for playing the recorded WAV voice greeting
// when the application first launches.


using System;
using System.IO;
using System.Media;

namespace CybersecurityBot
{
    /// <summary>
    /// Static helper class that handles all audio playback for the chatbot.
    /// Currently plays a WAV voice greeting on startup.
    public static class AudioHelper
    {
        private const string GreetingFileName = "greeting.wav";

        /// Plays the WAV voice greeting file when called.
        
        public static void PlayGreeting()
        {
            try
            {
                // Check that the WAV file actually exists before trying to play it
                if (File.Exists(GreetingFileName))
                {
                    using (SoundPlayer player = new SoundPlayer(GreetingFileName))
                    {
                        // PlaySync plays the audio and waits until it finishes
                        // before moving on — keeps the startup sequence in order
                        player.PlaySync();
                    }
                }
                else
                {
                    // File not found — warn the user but do not crash
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n  [Audio] 'greeting.wav' not found.");
                    Console.WriteLine("  Place your WAV file in the application folder and rebuild.");
                    Console.ResetColor();
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                // Something unexpected went wrong with audio playback
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n  [Audio Error] Could not play greeting: {ex.Message}");
                Console.ResetColor();
                Console.WriteLine();
            }
        }
    }
}