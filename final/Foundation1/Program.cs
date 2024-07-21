using System;
using System.Collections.Generic;

// Class to represent a Comment
public class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}

// Class to represent a Video
public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } // Length in seconds
    private List<Comment> comments;

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return comments.Count;
    }

    public List<Comment> GetComments()
    {
        return comments;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Create some videos
        Video video1 = new Video("Learning C#", "Tech Guru", 600);
        Video video2 = new Video("Cooking Pasta", "Chef John", 900);
        Video video3 = new Video("Travel Vlog: Paris", "Traveler Mike", 1200);

        // Add comments to videos
        video1.AddComment(new Comment("Alice", "Great tutorial!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Charlie", "Can you make a video on LINQ?"));

        video2.AddComment(new Comment("Diana", "Looks delicious!"));
        video2.AddComment(new Comment("Ethan", "I'm going to try this recipe tonight."));
        video2.AddComment(new Comment("Fiona", "Thanks for the tips!"));

        video3.AddComment(new Comment("George", "Paris is beautiful!"));
        video3.AddComment(new Comment("Hannah", "Loved the video, Mike!"));
        video3.AddComment(new Comment("Ivy", "Can't wait to visit Paris someday."));

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display video details and comments
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");

            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.Name}: {comment.Text}");
            }

            Console.WriteLine(); // Add a blank line for better readability
        }
    }
}
