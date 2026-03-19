using System;
using System.Collections.Generic;

namespace CybersecurityBot
{
    /// Contains all the predefined cybersecurity responses for the chatbot.
    /// Maps user keywords to informative, topic-specific replies.
    /// This class keeps response logic separate from the chat loop (separation of concerns).
    public class ResponseEngine
    {
        // Stores the user's name so responses can be personalised
        private readonly string _userName;

        // Dictionary mapping keyword triggers to response text
        private readonly Dictionary<string, string> _responses;

        /// Constructor — initialises the response engine with the user's name
        /// and pre-loads all the keyword-to-response mappings.
        public ResponseEngine(string userName)
        {
            _userName = userName;
            _responses = BuildResponseDictionary();
        }

        /// Builds and returns the dictionary of keyword triggers mapped to responses.
        /// Each key is a lowercase keyword that the user's input is checked against.
        private Dictionary<string, string> BuildResponseDictionary()
        {
            return new Dictionary<string, string>
            {
                // General conversational responses 

                ["how are you"] =
                    $"I'm running smoothly and fully focused on keeping you safe online, {_userName}! " +
                    "Cybersecurity never sleeps, and neither do I. 😄",

                ["purpose"] =
                    $"Great question, {_userName}! My purpose is to educate South African citizens " +
                    "like yourself about cybersecurity threats. I help you recognise phishing scams, " +
                    "create strong passwords, browse safely, and protect your personal information online.",

                ["what can i ask"] =
                    "You can ask me about: passwords, phishing, safe browsing, malware, " +
                    "social engineering, and online privacy. Type 'help' to see the full menu!",

                ["help"] =
                    "Showing you the topic menu now...",  // Handled specially in ChatBot.cs

                // Cybersecurity topic responses 

                ["password"] =
                    $"🔑 Password Safety Tips for you, {_userName}:\n\n" +
                    "  • Use at least 12 characters — the longer, the better.\n" +
                    "  • Mix uppercase, lowercase, numbers, and symbols (e.g. P@ssw0rd! is weak — be more creative).\n" +
                    "  • Never reuse passwords across different sites.\n" +
                    "  • Use a trusted password manager like Bitwarden or 1Password.\n" +
                    "  • Enable Two-Factor Authentication (2FA) wherever possible.\n" +
                    "  • Never share your password — not even with IT support!",

                ["phishing"] =
                    "🎣 How to Spot a Phishing Scam:\n\n" +
                    "  • Check the sender's email address carefully — look for subtle misspellings.\n" +
                    "  • Hover over links BEFORE clicking to see the actual URL.\n" +
                    "  • Be suspicious of urgent messages like 'Your account will be closed!'\n" +
                    "  • Legitimate banks and companies will NEVER ask for your password via email.\n" +
                    "  • Watch out for poor grammar and spelling — a common phishing giveaway.\n" +
                    "  • When in doubt, go directly to the website by typing the URL yourself.",

                ["browsing"] =
                    "🌐 Safe Browsing Habits:\n\n" +
                    "  • Always look for 'https://' and the padlock icon in the address bar.\n" +
                    "  • Avoid using public Wi-Fi for banking or sensitive tasks.\n" +
                    "  • If you must use public Wi-Fi, use a reputable VPN.\n" +
                    "  • Keep your browser and extensions up to date.\n" +
                    "  • Don't download files from untrusted websites.\n" +
                    "  • Clear your cookies and cache regularly to protect your privacy.",

                ["malware"] =
                    "🦠 Malware — What It Is and How to Stay Safe:\n\n" +
                    "  • Malware is malicious software designed to damage or gain access to your device.\n" +
                    "  • Types include: viruses, ransomware, spyware, trojans, and adware.\n" +
                    "  • Install reputable antivirus software and keep it updated.\n" +
                    "  • Don't open email attachments from unknown senders.\n" +
                    "  • Avoid clicking on pop-up ads — they often install malware.\n" +
                    "  • Regularly back up your important files to an external drive or cloud.",

                ["social"] =
                    "🎭 Social Engineering Awareness:\n\n" +
                    "  • Social engineering tricks people (not computers) into giving up sensitive info.\n" +
                    "  • Pretexting: Someone pretends to be a trusted authority (e.g. your bank, IT dept).\n" +
                    "  • Baiting: Leaving infected USB drives around hoping someone plugs them in.\n" +
                    "  • Vishing: Voice phishing — scam calls pretending to be from SARS or your bank.\n" +
                    "  • Always verify the identity of anyone requesting sensitive information.\n" +
                    "  • It's okay to hang up and call back on the official number to verify.",

                ["privacy"] =
                    $"🔐 Protecting Your Personal Information, {_userName}:\n\n" +
                    "  • Limit what personal info you share on social media.\n" +
                    "  • Review the privacy settings on all your social media accounts.\n" +
                    "  • Be careful what you share in public forums — it may be used against you.\n" +
                    "  • Shred physical documents containing personal info before disposing.\n" +
                    "  • Monitor your bank statements regularly for suspicious transactions.\n" +
                    "  • In South Africa, report identity theft to the South African Fraud Prevention Service (SAFPS).",
            };
        }

        /// Takes user input, checks it against known keywords, and returns an appropriate response.
        /// Returns null if no keyword match is found (handled as an unknown query).
        public string GetResponse(string userInput)
        {
            // Normalise input: trim whitespace and make lowercase for comparison
            string normalised = userInput.Trim().ToLower();

            // Check each keyword in the dictionary against the user's input
            foreach (var entry in _responses)
            {
                if (normalised.Contains(entry.Key))
                {
                    return entry.Value;
                }
            }

            // No keyword matched — return null to signal an unrecognised query
            return null;
        }
    }
}