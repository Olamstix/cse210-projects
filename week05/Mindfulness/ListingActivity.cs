using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people you appreciate?",
        "What are your personal strengths?",
        "Who have you helped recently?",
        "What blessings are in your life?"
    };

    public ListingActivity()
        : base("Listing",
        "This activity helps you focus on the good things in your life.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        Random random = new Random();
        Console.WriteLine($"\n{_prompts[random.Next(_prompts.Count)]}");
        Console.WriteLine("Start listing in:");
        ShowCountdown(5);

        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            items.Add(Console.ReadLine());
        }

        Console.WriteLine($"\nYou listed {items.Count} items!");
        DisplayEndingMessage();
    }
}
