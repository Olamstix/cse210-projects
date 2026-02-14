using System;
using System.Collections.Generic;

public class GratitudeActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "What made you smile today?",
        "Who are you grateful for?",
        "What opportunity are you thankful for?",
        "What challenge helped you grow?"
    };

    public GratitudeActivity()
        : base("Gratitude",
        "This activity helps you develop gratitude and positive thinking.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        Random random = new Random();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine($"\n{_prompts[random.Next(_prompts.Count)]}");
            ShowSpinner(5);
        }

        DisplayEndingMessage();
    }
}
