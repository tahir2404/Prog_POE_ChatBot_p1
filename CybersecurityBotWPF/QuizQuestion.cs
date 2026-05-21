using System.Collections.Generic;

namespace CybersecurityBotWPF.Quiz
{
    /// <summary>
    /// Represents one cybersecurity quiz question.
    /// Stores the question text, answer options,
    /// correct answer, and explanation.
    /// </summary>
    public class QuizQuestion
    {
        /// <summary>
        /// The question displayed to the user.
        /// </summary>
        public string QuestionText { get; set; } = "";

        /// <summary>
        /// The answer options for the question.
        /// </summary>
        public List<string> Options { get; set; } = new();

        /// <summary>
        /// The correct answer text.
        /// </summary>
        public string CorrectAnswer { get; set; } = "";

        /// <summary>
        /// Short explanation shown after the user answers.
        /// </summary>
        public string Explanation { get; set; } = "";
    }
}