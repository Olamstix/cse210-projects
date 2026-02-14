using System;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone.",
        "Think of a time you overcame something difficult.",
        "Think of a time you helped someone in need.",
        "Think of a time you showed real strength."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this meaningful to you?",
        "How did you feel afterward?",
        "What did you learn?",
        "How can you apply this again?",
        "What made this experience special?"
    };

    public ReflectionActivity()
        : base("Reflection",
        "This activity helps you reflect on times of strength and resilience.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        Random random = new Random();
        Console.WriteLine($"\n{_prompts[random.Next(_prompts.Count)]}");
        Console.WriteLine("\nReflect on the following questions:");
        ShowSpinner(3);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        List<string> usedQuestions = new List<string>();

        while (DateTime.Now < endTime)
        {
            if (usedQuestions.Count == _questions.Count)
            {
                usedQuestions.Clear();
            }

            string question;
            do
            {
                question = _questions[random.Next(_questions.Count)];
            }
            while (usedQuestions.Contains(question));

            usedQuestions.Add(question);

            Console.WriteLine($"\n{question}");
            ShowSpinner(4);
        }

        DisplayEndingMessage();
    }
}
