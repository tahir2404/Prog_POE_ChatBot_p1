using CybersecurityBotWPF;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Media;

namespace CybersecurityBotWPF
{
    /// <summary>
    /// Interaction logic for the main chatbot window. Handles user interaction, message display and communication between the GUI and chatbot logic.
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
        /// Constructor for the MainWindow.Initialises the GUI components, plays the greeting audio and displays the startup messages.
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
        /// Processes the user's input from the textbox. If it is the first message it stores the user's name. After that it sends normal questions to the chatbot.
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
        /// Displays a formatted user message in the chat display area.
        /// </summary>
        /// <summary>
        /// Displays the user's message on the right side of the chat area using a styled message bubble.
        /// </summary>
        private void AddUserMessage(string message)
        {
            TextBlock messageText = new TextBlock
            {
                Text = message,
                TextWrapping = TextWrapping.Wrap,
                Foreground = Brushes.Black,
                FontSize = 14
            };

            Border bubble = new Border
            {
                Background = Brushes.Cyan,
                CornerRadius = new CornerRadius(12),
                Padding = new Thickness(10),
                Margin = new Thickness(80, 5, 5, 5),
                HorizontalAlignment = HorizontalAlignment.Right,
                MaxWidth = 500,
                Child = messageText
            };

            ChatPanel.Children.Add(bubble);
            ChatScrollViewer.ScrollToEnd();
        }

        /// <summary>
        /// Displays the chatbot's message on the left side of the chat area using a styled message bubble.
        /// </summary>
        private void AddBotMessage(string message)
        {
            TextBlock messageText = new TextBlock
            {
                Text = message,
                TextWrapping = TextWrapping.Wrap,
                Foreground = Brushes.White,
                FontSize = 14
            };

            Border bubble = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(51, 65, 85)),
                CornerRadius = new CornerRadius(12),
                Padding = new Thickness(10),
                Margin = new Thickness(5, 5, 80, 5),
                HorizontalAlignment = HorizontalAlignment.Left,
                MaxWidth = 600,
                Child = messageText
            };

            ChatPanel.Children.Add(bubble);
            ChatScrollViewer.ScrollToEnd();
        }
    }
}