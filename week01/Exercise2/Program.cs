using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask the user for their grade percentage
        Console.Write("What is your grade percentage? ");
        string input = Console.ReadLine();

        // Convert input to integer
        int percent;
        if (!int.TryParse(input, out percent) || percent < 0 || percent > 100)
        {
            Console.WriteLine("Invalid input. Please enter a number between 0 and 100.");
            return;
        }

        string letter = "";
        string sign = "";

        // Determine letter grade
        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Determine the grade sign (+ or -) except for special cases
        int lastDigit = percent % 10;

        if (letter != "A" && letter != "F") // A+ doesn't exist, and F has no + or -
        {
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }
        else if (letter == "A" && lastDigit < 3)
        {
            sign = "-"; // A- exists, but no A+

        }

        // Print the final grade
        Console.WriteLine($"Your grade is: {letter}{sign}");

        // Determine if the student passed
        if (percent >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Better luck next time! Keep working hard.");
        }
    }
}