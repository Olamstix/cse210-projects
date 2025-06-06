using System;

/// <summary>
/// Scripture Memorizer Program - W03 Project
/// 
/// Enhancements Beyond Core Requirements:
/// - Added a "completion percentage" tracker that displays the percent of hidden words after each round.
///   This helps users track their memorization progress visually.
/// - Code is structured using principles of encapsulation with dedicated classes for Reference, Scripture, and Word.
/// </summary>
class Program
{
    static void Main()
    {
        // Create a reference for a verse range
        var reference = new Reference("Proverbs", 3, 5, 6);

        // Initialize the scripture with text
        var scripture = new Scripture(reference,
            "Trust in the Lord with all thine heart and lean not unto thine own understanding");

        // Loop until all words are hidden
        while (!scripture.AllWordsHidden())
        {
            Console.Clear();

            // Display scripture with hidden words
            Console.WriteLine(scripture.GetDisplayText());

            // Enhancement: Show progress percentage
            double percent = scripture.GetCompletionPercentage();
            Console.WriteLine($"\nProgress: {percent:F1}% hidden");

            // User prompt
            Console.WriteLine("\nPress Enter to continue or type 'quit' to finish:");
            string input = Console.ReadLine();

            // Exit if user types "quit"
            if (input.Trim().ToLower() == "quit") break;

            // Hide 3 random words each round
            scripture.HideRandomWords(3);
        }

        // Final display when all words are hidden
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nAll words are now hidden. Program ended.");
    }
}
