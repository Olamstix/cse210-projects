/*
EXCEEDING REQUIREMENTS – Mindfulness Program

In addition to meeting all core requirements, the following enhancements were added:

1. Added a new GratitudeActivity class:
   - This provides an additional mindfulness activity beyond the required three.
   - It promotes gratitude-focused reflection with randomized prompts.

2. Implemented activity logging to an external file:
   - Each completed activity is saved to "activity_log.txt".
   - The log records the date, activity name, and duration.
   - This demonstrates file handling and persistent data storage.

3. Prevented duplicate reflection questions:
   - ReflectionActivity tracks which questions have been used.
   - Questions are not repeated until all have been shown.
   - This improves user experience and program logic.

4. Added session tracking:
   - The program keeps track of how many activities are completed during the current session.
   - The total is displayed in the main menu.

5. Enhanced breathing animation:
   - Instead of only using a countdown, a visual expanding and contracting pattern 
     (using asterisks) simulates breathing.
   - This creates a more engaging and meaningful animation experience.

These improvements demonstrate additional object-oriented design, file handling,
state management, and enhanced user interaction beyond the assignment’s minimum requirements.
*/







using System;

class Program
{
    static int totalActivities = 0;

    static void Main(string[] args)
    {
        string choice = "";

        while (choice != "5")
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program\n");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Gratitude Activity");
            Console.WriteLine("5. Quit");
            Console.WriteLine($"\nActivities completed this session: {totalActivities}");
            Console.Write("\nSelect a choice: ");

            choice = Console.ReadLine();

            if (choice == "1")
            {
                new BreathingActivity().Run();
                totalActivities++;
            }
            else if (choice == "2")
            {
                new ReflectionActivity().Run();
                totalActivities++;
            }
            else if (choice == "3")
            {
                new ListingActivity().Run();
                totalActivities++;
            }
            else if (choice == "4")
            {
                new GratitudeActivity().Run();
                totalActivities++;
            }
        }
    }
}
