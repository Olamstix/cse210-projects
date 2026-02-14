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
