using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries;
    private List<string> _prompts;
    private Random _random;

    public Journal()
    {
        _entries = new List<Entry>();
        _random = new Random();

        // Initial prompt list
        _prompts = new List<string>()
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };
    }

    public void WriteEntry()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine("Prompt: " + prompt);
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        string date = DateTime.Now.ToString("yyyy-MM-dd");
        Entry newEntry = new Entry(prompt, response, date);
        _entries.Add(newEntry);

        Console.WriteLine("Entry saved!\n");
    }

    public void DisplayEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No journal entries found.\n");
            return;
        }

        foreach (Entry entry in _entries)
        {
            Console.WriteLine($"Date: {entry.Date}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Response: {entry.Response}");
            Console.WriteLine("----------------------------");
        }
    }

    public void SaveToFile()
    {
        Console.Write("Enter filename to save journal: ");
        string filename = Console.ReadLine();

        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Entry entry in _entries)
                {
                    // Use a custom delimiter to avoid conflicts
                    writer.WriteLine($"{entry.Date}~|~{entry.Prompt}~|~{entry.Response}");
                }
            }
            Console.WriteLine("Journal saved successfully.\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal: {ex.Message}\n");
        }
    }

    public void LoadFromFile()
    {
        Console.Write("Enter filename to load journal: ");
        string filename = Console.ReadLine();

        try
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("File does not exist.\n");
                return;
            }

            List<Entry> loadedEntries = new List<Entry>();
            string[] lines = File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                string[] parts = line.Split(new string[] { "~|~" }, StringSplitOptions.None);
                if (parts.Length == 3)
                {
                    loadedEntries.Add(new Entry(parts[1], parts[2], parts[0]));
                }
            }

            _entries = loadedEntries;
            Console.WriteLine("Journal loaded successfully.\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal: {ex.Message}\n");
        }
    }

    private string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }

    public void AddPrompt()
    {
        Console.Write("Enter a new journal prompt to add: ");
        string newPrompt = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newPrompt))
        {
            _prompts.Add(newPrompt);
            Console.WriteLine("New prompt added successfully!\n");
        }
        else
        {
            Console.WriteLine("Prompt cannot be empty.\n");
        }
    }
}
