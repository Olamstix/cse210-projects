using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference reference;
    private List<Word> words;
    private Random rand = new Random();

    public Scripture(Reference reference, string text)
    {
        this.reference = reference;
        words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    public void HideRandomWords(int count)
    {
        var visibleWords = words.Where(w => !w.IsHidden()).ToList();
        if (visibleWords.Count == 0) return;

        for (int i = 0; i < count && visibleWords.Count > 0; i++)
        {
            int index = rand.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public string GetDisplayText()
    {
        string text = string.Join(" ", words.Select(w => w.GetDisplayText()));
        return $"{reference}\n{text}";
    }

    public bool AllWordsHidden()
    {
        return words.All(w => w.IsHidden());
    }

    public double GetCompletionPercentage()
    {
        int total = words.Count;
        int hidden = words.Count(w => w.IsHidden());
        return (double)hidden / total * 100;
    }
}
