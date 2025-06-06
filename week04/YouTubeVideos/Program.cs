using System;
using System.Collections.Generic;

class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}

class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } // in seconds
    private List<Comment> Comments = new List<Comment>();

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return Comments.Count;
    }

    public void DisplayVideoDetails()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length} seconds");
        Console.WriteLine($"Comments ({GetCommentCount()}):");
        foreach (Comment c in Comments)
        {
            Console.WriteLine($"  - {c.Name}: {c.Text}");
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("Understanding C#", "John Doe", 300);
        video1.AddComment(new Comment("Alice", "Great explanation!"));
        video1.AddComment(new Comment("Bob", "Very helpful."));
        video1.AddComment(new Comment("Charlie", "Can you do one on interfaces?"));
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("Design Patterns in OOP", "Jane Smith", 420);
        video2.AddComment(new Comment("Dan", "Loved the visuals."));
        video2.AddComment(new Comment("Eve", "Singleton pattern finally makes sense!"));
        video2.AddComment(new Comment("Frank", "Subscribed!"));
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("Debugging in VS Code", "Techie Tuts", 180);
        video3.AddComment(new Comment("Grace", "Clear and concise."));
        video3.AddComment(new Comment("Heidi", "Thanks! This saved me time."));
        video3.AddComment(new Comment("Ivan", "More like this, please!"));
        videos.Add(video3);

        // Display all video details
        foreach (Video video in videos)
        {
            video.DisplayVideoDetails();
        }
    }
}
