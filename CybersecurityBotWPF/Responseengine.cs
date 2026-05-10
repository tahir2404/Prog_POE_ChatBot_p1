using System;
using System.Collections.Generic;

namespace CybersecurityBotWPF
{
    /// <summary>
    /// Manages all chatbot responses for cybersecurity topics. Uses a dictionary of keyword lists so the bot can give random, varied responses instead of repeating the same answer.
    /// </summary>
    public class ResponseEngine
    {
        /// <summary>
        /// The current user's name. Used to personalise chatbot responses.
        /// </summary>
        public string UserName { get; private set; }

        // Random object used to choose different responses from each topic list
        private readonly Random _random = new Random();

        // Stores keywords and multiple possible responses for each keyword
        private readonly Dictionary<string, List<string>> _responses;

        /// <summary>
        /// Creates a new ResponseEngine for the given user. Loads all predefined keyword responses into the dictionary.
        /// </summary>
        public ResponseEngine(string userName)
        {
            UserName = userName;
            _responses = BuildResponses();
        }

        /// <summary>
        /// Builds the dictionary that links cybersecurity keywords to lists of possible chatbot responses.
        /// </summary>
        private Dictionary<string, List<string>> BuildResponses()
        {
            return new Dictionary<string, List<string>>
            {
                ["how are you"] = new List<string>
                {
                    $"I'm running perfectly and fully focused on keeping you cyber-safe, {UserName}!",
                    $"I'm doing great, {UserName}. Ready to help you stay safe online."
                },

                ["purpose"] = new List<string>
                {
                    $"My purpose is to educate South African citizens about cybersecurity threats, {UserName}. I can help with phishing, scams, passwords, malware, privacy and safe browsing.",
                    $"I'm here to help you understand online safety in a simple way, {UserName}. Think of me as your digital safety guide."
                },

                ["what can i ask"] = new List<string>
                {
                    "You can ask me about passwords, phishing, scams, privacy, safe browsing, malware, and social engineering.",
                    "Try asking about password safety, phishing tips, online scams, privacy settings, or safe browsing habits."
                },

                ["help"] = new List<string>
                {
                    "You can ask me about:\n\n• password safety\n• phishing\n• scams\n• privacy\n• safe browsing\n• malware\n• social engineering\n\nYou can also ask for another tip or say tell me more."
                },

                ["password"] = new List<string>
                {
                    $"Password safety tip for you, {UserName}: use long, unique passwords for every account.",
                    "A strong password should include uppercase letters, lowercase letters, numbers, and special symbols.",
                    "Never reuse the same password on different websites. If one account is hacked, the others could be at risk.",
                    "Use a trusted password manager to store your passwords safely.",
                    "Enable two-factor authentication whenever possible for extra account protection."
                },

                ["phishing"] = new List<string>
                {
                    "Be careful of emails asking for personal information. Scammers often pretend to be trusted organisations.",
                    "Always check the sender's email address carefully before clicking links or downloading attachments.",
                    "Phishing messages often use urgent language like 'your account will be closed'. Stay calm and verify first.",
                    "Hover over links before clicking to check where they really go.",
                    "If you are unsure, go directly to the official website instead of clicking the link."
                },

                ["scam"] = new List<string>
                {
                    "Online scams often pressure you to act quickly. Take your time and verify before responding.",
                    "Never share your banking PIN, password, or OTP with anyone, even if they claim to be from your bank.",
                    "If an offer sounds too good to be true, it is probably a scam.",
                    "Scammers may pretend to be from trusted companies or government departments. Always verify using official contact details.",
                    "Be careful of WhatsApp, SMS, and email messages asking you to click unknown links."
                },

                ["privacy"] = new List<string>
                {
                    $"Privacy tip, {UserName}: review your social media privacy settings regularly.",
                    "Avoid sharing too much personal information online, such as your address, school, ID number, or daily routine.",
                    "Use strong privacy settings on apps and websites to control who can see your information.",
                    "Be careful when posting photos that reveal your location or private details.",
                    "Regularly check app permissions and remove access you no longer need."
                },

                ["browsing"] = new List<string>
                {
                    "Safe browsing tip: only visit websites you trust and check for https:// in the address bar.",
                    "Avoid entering personal information on websites that do not have a secure padlock icon.",
                    "Be careful with pop-ups that ask you to download software or claim your device is infected.",
                    "Avoid using public Wi-Fi for banking or sensitive activities unless you are using a trusted VPN.",
                    "Keep your browser and extensions updated to reduce security risks."
                },

                ["malware"] = new List<string>
                {
                    "Malware is harmful software that can damage your device or steal information.",
                    "Avoid opening email attachments from unknown or unexpected senders.",
                    "Install trusted antivirus software and keep it updated.",
                    "Only download apps and software from official websites or app stores.",
                    "Back up your important files so you are protected if ransomware attacks your device."
                },

                ["social"] = new List<string>
                {
                    "Social engineering is when criminals trick people into giving away private information.",
                    "Always verify the identity of someone asking for sensitive information.",
                    "Do not feel pressured to respond immediately to suspicious calls, messages, or emails.",
                    "If someone claims to be from your bank, hang up and call the official number yourself.",
                    "Trust your instincts. If something feels suspicious, verify it first."
                }
            };
        }

        /// <summary>
        /// Searches the user's input for a recognised keyword. If a keyword is found, the method returns a random response from that keyword's response list.
        /// </summary>
        public string? GetResponse(string userInput)
        {
            string normalised = userInput.Trim().ToLower();

            foreach (KeyValuePair<string, List<string>> entry in _responses)
            {
                if (normalised.Contains(entry.Key))
                {
                    int index = _random.Next(entry.Value.Count);
                    return entry.Value[index];
                }
            }

            return null;
        }
    }
}