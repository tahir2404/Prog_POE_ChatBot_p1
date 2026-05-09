using CybersecurityBot;
using System.Windows;
using System.Windows.Input;

namespace CybersecurityBotWPF
{
    /// <summary>
    /// Interaction logic for the main chatbot window. Handles user interaction, message display, and communication between the GUI and chatbot logic.
    /// </summary>
    public partial class MainWindow : Window
    {
        // Main chatbot object used to process responses
        private ChatBot _chatBot;

        /// <summary>
        /// Constructor for the MainWindow. Initialises the GUI components, plays the greeting audio and displays the startup messages.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            // Play the startup voice greeting
            AudioHelper.PlayGreeting();

            // Create chatbot instance
            _chatBot = new ChatBot("User");

            // Display startup welcome messages
            AddBotMessage("Welcome to the Cybersecurity Awareness Assistant!");
            AddBotMessage("Please type your name to begin.");
        }

        /// <summary>
        /// Triggered when the Send button is clicked. Sends the user's message to the chatbot.
        /// </summary>
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            HandleUserInput();
        }

        /// <summary>
        /// Allows the Enter key to submit messages instead of only using the Send button.
        /// </summary>
        private void UserInputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                HandleUserInput();
            }
        }

        /// <summary>
        /// Processes the user's input from the textbox, displays it in the chat area, gets the chatbot response and displays the response.
        /// </summary>
        private void HandleUserInput()
        {
            // Get the user's typed message
            string input = UserInputBox.Text.Trim();

            // Prevent empty submissions
            if (string.IsNullOrWhiteSpace(input))
            {
                AddBotMessage("Please type something before pressing send.");
                return;
            }

            // Display the user's message
            AddUserMessage(input);

            // Get chatbot response
            string response = _chatBot.GetBotResponse(input);

            // Display chatbot response
            AddBotMessage(response);

            // Clear input box for next message
            UserInputBox.Clear();

            // Return focus to textbox
            UserInputBox.Focus();
        }

        /// <summary>
        /// Displays a formatted user message in the chat display area.
        /// </summary>
        private void AddUserMessage(string message)
        {
            ChatDisplay.Text += $"\nYou: {message}\n";
        }

        /// <summary>
        /// Displays a formatted chatbot response in the chat display area.
        /// </summary>
        private void AddBotMessage(string message)
        {
            ChatDisplay.Text += $"Bot: {message}\n";
        }
    }
}