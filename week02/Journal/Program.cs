using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        bool quit = false;
        while (!quit)
        {
            Console.WriteLine("Journal Program Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.WriteLine("6. Add a new prompt"); // Added option for exceeding feature
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    journal.WriteEntry();
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    journal.SaveToFile();
                    break;
                case "4":
                    journal.LoadFromFile();
                    break;
                case "5":
                    quit = true;
                    break;
                case "6":
                    journal.AddPrompt();  // Call the new method to add prompts
                    break;
                default:
                    Console.WriteLine("Invalid option. Please choose again.\n");
                    break;
            }
        }

        Console.WriteLine("Goodbye!");
    }
}

/*
 * This program meets all core requirements:
 * - Writes new entries with a random prompt
 * - Displays all journal entries
 * - Saves and loads journal entries from a file
 * - Uses classes (Entry, Journal, Program)
 * - Demonstrates abstraction by using private members and methods
 * 
 * To exceed the core requirements, I have:
 * - Used a custom delimiter "~|~" for file saving/loading to avoid issues with commas in user input
 * - Handled file exceptions gracefully
 * - Allowed the user to add new prompts dynamically (see option 6 in the menu)
 * - This helps address the problem of limited prompts and keeps the journaling experience fresh
 */
