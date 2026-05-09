using System;
using System.IO;
using System.Media;

namespace CybersecurityBotWPF
{
    /// <summary>
    /// Static helper class that handles audio playback for the chatbot.
    /// Plays the WAV voice greeting when the WPF application starts.
    /// </summary>
    public static class AudioHelper
    {
        // Location of the WAV file inside the project output folder
        private const string GreetingFilePath = "Assets/greeting.wav";

        /// <summary>
        /// Plays the greeting audio file when the application opens.
        /// Returns a message so the GUI can handle success or error feedback if needed.
        /// </summary>
        /// <returns>Status message showing whether the audio played successfully.</returns>
        public static string PlayGreeting()
        {
            try
            {
                if (File.Exists(GreetingFilePath))
                {
                    using SoundPlayer player = new SoundPlayer(GreetingFilePath);
                    player.Play();
                    return "Voice greeting played successfully.";
                }

                return "Audio file not found. Please make sure greeting.wav is inside the Assets folder.";
            }
            catch (Exception ex)
            {
                return $"Audio error: {ex.Message}";
            }
        }
    }
}