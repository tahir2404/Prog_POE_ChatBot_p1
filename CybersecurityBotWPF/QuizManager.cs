using System.Collections.Generic;

namespace CybersecurityBotWPF.Quiz
{
    /// <summary>
    /// Manages the cybersecurity quiz game. Handles question loading, answer checking, score tracking and quiz progress.
    /// </summary>
    public class QuizManager
    {
        private readonly List<QuizQuestion> _questions;
        private int _currentQuestionIndex;
        private int _score;

        /// <summary>
        /// Indicates whether the quiz is currently active.
        /// </summary>
        public bool IsQuizActive { get; private set; }

        /// <summary>
        /// Creates a new quiz manager and loads quiz questions.
        /// </summary>
        public QuizManager()
        {
            _questions = LoadQuestions();
            _currentQuestionIndex = 0;
            _score = 0;
            IsQuizActive = false;
        }

        /// <summary>
        /// Starts the quiz and returns the first question.
        /// </summary>
        public string StartQuiz()
        {
            _currentQuestionIndex = 0;
            _score = 0;
            IsQuizActive = true;

            return "Cybersecurity Quiz started!\n\n" + GetCurrentQuestionText();
        }

        /// <summary>
        /// Checks the user's answer and moves to the next question.
        /// </summary>
        public string SubmitAnswer(string userAnswer)
        {
            if (!IsQuizActive)
            {
                return "The quiz has not started yet. Type 'start quiz' to begin.";
            }

            QuizQuestion currentQuestion = _questions[_currentQuestionIndex];

            bool isCorrect = userAnswer.Trim().Equals(
                currentQuestion.CorrectAnswer,
                System.StringComparison.OrdinalIgnoreCase);

            string feedback;

            if (isCorrect)
            {
                _score++;
                feedback = "Correct!\n";
            }
            else
            {
                feedback = $"Incorrect. The correct answer was: {currentQuestion.CorrectAnswer}\n";
            }

            feedback += currentQuestion.Explanation + "\n\n";

            _currentQuestionIndex++;

            if (_currentQuestionIndex >= _questions.Count)
            {
                IsQuizActive = false;
                return feedback + GetFinalScore();
            }

            return feedback + GetCurrentQuestionText();
        }

        /// <summary>
        /// Returns the current quiz question with answer options.
        /// </summary>
        private string GetCurrentQuestionText()
        {
            QuizQuestion question = _questions[_currentQuestionIndex];

            string text = $"Question {_currentQuestionIndex + 1} of {_questions.Count}:\n";
            text += question.QuestionText + "\n\n";

            foreach (string option in question.Options)
            {
                text += option + "\n";
            }

            return text;
        }

        /// <summary>
        /// Returns the user's final quiz score and feedback.
        /// </summary>
        private string GetFinalScore()
        {
            string result = $"Quiz complete! Your score is {_score}/{_questions.Count}.\n";

            if (_score >= 9)
            {
                result += "Great job! You're a cybersecurity pro!";
            }
            else if (_score >= 6)
            {
                result += "Good work! You understand many cybersecurity basics.";
            }
            else
            {
                result += "Keep learning. Cybersecurity awareness improves with practice.";
            }

            return result;
        }

        /// <summary>
        /// Loads the cybersecurity quiz questions. Includes multiple-choice and true/false questions.
        /// </summary>
        private List<QuizQuestion> LoadQuestions()
        {
            return new List<QuizQuestion>
            {
                new QuizQuestion
                {
                    QuestionText = "What should you do if you receive an email asking for your password?",
                    Options = new List<string>
                    {
                        "A) Reply with your password",
                        "B) Delete or report the email",
                        "C) Forward it to friends",
                        "D) Ignore all security warnings"
                    },
                    CorrectAnswer = "B",
                    Explanation = "Legitimate organisations should not ask for your password by email."
                },

                new QuizQuestion
                {
                    QuestionText = "True or False: You should use the same password for all your accounts.",
                    Options = new List<string>
                    {
                        "True",
                        "False"
                    },
                    CorrectAnswer = "False",
                    Explanation = "Reusing passwords is risky because one breach can affect many accounts."
                },

                new QuizQuestion
                {
                    QuestionText = "Which password is the strongest?",
                    Options = new List<string>
                    {
                        "A) password123",
                        "B) tahir2005",
                        "C) Q9!vL#82mP@x",
                        "D) 123456"
                    },
                    CorrectAnswer = "C",
                    Explanation = "Strong passwords are long, unique, and include mixed characters."
                },

                new QuizQuestion
                {
                    QuestionText = "What does 2FA help with?",
                    Options = new List<string>
                    {
                        "A) Adds an extra layer of login security",
                        "B) Makes your screen brighter",
                        "C) Deletes spam automatically",
                        "D) Speeds up your internet"
                    },
                    CorrectAnswer = "A",
                    Explanation = "Two-factor authentication adds another step to protect your account."
                },

                new QuizQuestion
                {
                    QuestionText = "True or False: Public Wi-Fi is always safe for online banking.",
                    Options = new List<string>
                    {
                        "True",
                        "False"
                    },
                    CorrectAnswer = "False",
                    Explanation = "Public Wi-Fi can be unsafe. Avoid banking on public networks."
                },

                new QuizQuestion
                {
                    QuestionText = "What is phishing?",
                    Options = new List<string>
                    {
                        "A) A method of catching fish",
                        "B) A scam used to steal personal information",
                        "C) A safe browsing tool",
                        "D) A type of antivirus"
                    },
                    CorrectAnswer = "B",
                    Explanation = "Phishing tricks users into giving away sensitive information."
                },

                new QuizQuestion
                {
                    QuestionText = "What should you check before clicking a link?",
                    Options = new List<string>
                    {
                        "A) The real URL",
                        "B) The colour of the email",
                        "C) The length of the message only",
                        "D) Nothing"
                    },
                    CorrectAnswer = "A",
                    Explanation = "Checking the real URL helps avoid fake or harmful websites."
                },

                new QuizQuestion
                {
                    QuestionText = "True or False: Antivirus software should be kept updated.",
                    Options = new List<string>
                    {
                        "True",
                        "False"
                    },
                    CorrectAnswer = "True",
                    Explanation = "Updates help antivirus software detect newer threats."
                },

                new QuizQuestion
                {
                    QuestionText = "What is social engineering?",
                    Options = new List<string>
                    {
                        "A) Building social media apps",
                        "B) Manipulating people into revealing information",
                        "C) Fixing computer hardware",
                        "D) Designing websites"
                    },
                    CorrectAnswer = "B",
                    Explanation = "Social engineering targets people by manipulating trust."
                },

                new QuizQuestion
                {
                    QuestionText = "What should you do if an online offer sounds too good to be true?",
                    Options = new List<string>
                    {
                        "A) Trust it immediately",
                        "B) Share your banking details",
                        "C) Verify it first",
                        "D) Click every link"
                    },
                    CorrectAnswer = "C",
                    Explanation = "Scams often use unrealistic offers to trick people."
                },

                new QuizQuestion
                {
                    QuestionText = "True or False: You should share your OTP with someone claiming to be from your bank.",
                    Options = new List<string>
                    {
                        "True",
                        "False"
                    },
                    CorrectAnswer = "False",
                    Explanation = "Never share OTPs, PINs, or passwords with anyone."
                }
            };
        }
    }
}