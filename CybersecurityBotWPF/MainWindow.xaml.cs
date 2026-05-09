using CybersecurityBot;
using System.Windows;
using System.Windows.Input;

namespace CybersecurityBotWPF
{
    /// <summary>
    /// Interaction logic for the main chatbot window.
    /// Handles user interaction, message display,
    /// and communication between the GUI and chatbot logic.
    /// </summary>
    public partial class MainWindow : Window
    {
        // Main chatbot object used to process responses
        private ChatBot? _chatBot;

        // Stores whether the user has already entered their name
        private bool _hasUserEnteredName = false;

        // Stores the user's name after the first input
        private string _userName = "User";

        /// <summary>
        /// Constructor for the MainWindow.
        /// Initialises the GUI components,
        /// plays the greeting audio,
        /// and displays the startup messages.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            // Play the startup voice greeting
            string audioMessage = AudioHelper.PlayGreeting();

            // Display startup welcome messages
            AddBotMessage("Welcome to the Cybersecurity Awareness Assistant!");
            AddBotMessage("Please type your name to begin.");
        }

        /// <summary>
        /// Triggered when the Send button is clicked.
        /// Sends the user's message to the chatbot.
        /// </summary>
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            HandleUserInput();
        }

        /// <summary>
        /// Allows the Enter key to submit messages
        /// instead of only using the Send button.
        /// </summary>
        private void UserInputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                HandleUserInput();
            }
        }

        /// <summary>
        /// Processes the user's input from the textbox.
        /// If it is the first message, it stores the user's name.
        /// After that, it sends normal questions to the chatbot.
        /// </summary>
        private void HandleUserInput()
        {
            string input = UserInputBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                AddBotMessage("Please type something before pressing send.");
                return;
            }

            AddUserMessage(input);

            if (!_hasUserEnteredName)
            {
                _userName = input;
                _chatBot = new ChatBot(_userName);
                _hasUserEnteredName = true;

                AddBotMessage($"Nice to meet you, {_userName}!");
                AddBotMessage("You can ask me about password safety, phishing, scams, privacy, malware, safe browsing, or social engineering.");
                AddBotMessage("Type 'help' if you want to see the topics again.");

                UserInputBox.Clear();
                UserInputBox.Focus();
                return;
            }

            string response = _chatBot!.GetBotResponse(input);

            AddBotMessage(response);

            UserInputBox.Clear();
            UserInputBox.Focus();
        }

        /// <summary>
        /// Displays a formatted user message
        /// in the chat display area.
        /// </summary>
        private void AddUserMessage(string message)
        {
            ChatDisplay.Text += $"\nYou: {message}\n";
        }

        /// <summary>
        /// Displays a formatted chatbot response
        /// in the chat display area.
        /// </summary>
        private void AddBotMessage(string message)
        {
            ChatDisplay.Text += $"Bot: {message}\n";
        }
    }
}