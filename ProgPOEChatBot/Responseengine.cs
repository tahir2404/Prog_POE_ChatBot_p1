
// Contains all predefined cybersecurity responses.
// Stores keyword-to-response mappings in a Dictionary.

using System;
using System.Collections.Generic;

namespace CybersecurityBot
{
    /// <summary>
    /// Manages all predefined chatbot responses.
    /// Matches user input against known cybersecurity keywords
    /// and returns the appropriate response.
    public class ResponseEngine
    {

        /// <summary>
        /// The current user's name. Used to personalise responses.
        public string UserName { get; private set; }

        private readonly Dictionary<string, string> _responses;


        /// <summary>
        /// Creates a new ResponseEngine for the given user.
        /// Pre-loads all keyword responses into the dictionary on startup.
       
        public ResponseEngine(string userName)
        {
            UserName = userName;
            _responses = BuildResponses();
        }


        /// <summary>
        /// Builds and returns the full dictionary of keyword-to-response.
       
        private Dictionary<string, string> BuildResponses()
        {
            return new Dictionary<string, string>
            {

                ["how are you"] =
                    $"I'm running perfectly and fully focused on keeping you cyber-safe, {UserName}! " +
                    "Cybersecurity never sleeps — and neither do I. 😄",

                ["purpose"] =
                    $"Great question, {UserName}! My purpose is to educate South African citizens about " +
                    "cybersecurity threats. I can help you recognise phishing scams, create strong " +
                    "passwords, browse safely, and protect your personal information online. " +
                    "Think of me as your digital safety guide!",

                ["what can i ask"] =
                    "You can ask me about passwords, phishing, safe browsing, malware, " +
                    "social engineering, and online privacy. Type 'help' to see the full menu!",

                // Cybersecurity Topics 

                ["password"] =
                    $" Password Safety Tips for you, {UserName}:\n\n" +
                    "  • Use at least 12 characters — the longer the better.\n" +
                    "  • Mix uppercase, lowercase, numbers, and special symbols.\n" +
                    "  • Never reuse the same password on multiple sites.\n" +
                    "  • Use a trusted password manager (e.g. Bitwarden or 1Password).\n" +
                    "  • Enable Two-Factor Authentication (2FA) wherever possible.\n" +
                    "  • Never share your password — not even with IT support!\n" +
                    "  • Change your passwords regularly, especially after a data breach.",

                ["phishing"] =
                    " How to Spot a Phishing Scam:\n\n" +
                    "  • Carefully check the sender's email address for subtle misspellings.\n" +
                    "  • Hover over links BEFORE clicking to preview the real URL.\n" +
                    "  • Be suspicious of urgent messages like 'Your account will be closed!'\n" +
                    "  • Legitimate organisations will NEVER ask for your password via email.\n" +
                    "  • Poor grammar and spelling are common phishing red flags.\n" +
                    "  • When in doubt, go directly to the website by typing the URL yourself.\n" +
                    "  • Report phishing emails to your email provider.",

                ["browsing"] =
                    " Safe Browsing Habits:\n\n" +
                    "  • Always look for 'https://' and the padlock icon in the address bar.\n" +
                    "  • Avoid using public Wi-Fi for banking or any sensitive activity.\n" +
                    "  • If you must use public Wi-Fi, connect through a reputable VPN.\n" +
                    "  • Keep your browser and all extensions up to date.\n" +
                    "  • Only download software from official, trusted websites.\n" +
                    "  • Clear your cookies and cache regularly to protect your privacy.\n" +
                    "  • Be cautious of pop-ups asking you to install anything.",

                ["malware"] =
                    " Malware — What It Is and How to Stay Protected:\n\n" +
                    "  • Malware is malicious software designed to damage or access your device.\n" +
                    "  • Common types: viruses, ransomware, spyware, trojans, and adware.\n" +
                    "  • Install a reputable antivirus program and keep it updated.\n" +
                    "  • Never open email attachments from unknown or unexpected senders.\n" +
                    "  • Avoid clicking on pop-up ads — they often install malware silently.\n" +
                    "  • Regularly back up your files to an external drive or secure cloud.\n" +
                    "  • Keep your operating system updated — patches fix security holes.",

                ["social"] =
                    " Social Engineering Awareness:\n\n" +
                    "  • Social engineering manipulates people — not computers — into giving up info.\n" +
                    "  • Pretexting: Someone pretends to be a trusted authority (e.g. SARS, your bank).\n" +
                    "  • Baiting: Infected USB drives left in public, hoping someone plugs one in.\n" +
                    "  • Vishing: Scam phone calls pretending to be from your bank or government.\n" +
                    "  • Always verify the identity of anyone requesting sensitive information.\n" +
                    "  • It is okay to hang up and call back on the official published number.\n" +
                    "  • When something feels off — trust your instincts and verify first.",

                ["privacy"] =
                    $" Protecting Your Personal Information, {UserName}:\n\n" +
                    "  • Limit the personal details you share publicly on social media.\n" +
                    "  • Regularly review and tighten privacy settings on all your accounts.\n" +
                    "  • Be careful what you share in public forums — it can be used against you.\n" +
                    "  • Shred physical documents containing personal info before disposing.\n" +
                    "  • Monitor your bank statements regularly for any suspicious activity.\n" +
                    "  • In South Africa, report identity theft to the SAFPS (safps.org.za).\n" +
                    "  • Use unique email addresses for important accounts where possible.",
            };
        }


        /// <summary>
        /// Looks up a response based on keywords found in the user's input.
        /// Returns null if no matching keyword is found.
        
        public string? GetResponse(string userInput)
        {
            // Normalise: remove surrounding whitespace and convert to lowercase
            string normalised = userInput.Trim().ToLower();

            // Check each keyword against the normalised input
            foreach (KeyValuePair<string, string> entry in _responses)
            {
                // String.Contains checks if the keyword appears anywhere in the input
                if (normalised.Contains(entry.Key))
                {
                    return entry.Value;
                }
            }

            // No keyword matched
            return null;
        }
    }
}