using System;
using System.Collections.Generic;

// Scripture class to manage scripture text and word hiding
public class Scripture
{
    private string scriptureText;
    private List<string> hiddenWords;

    public Scripture(string text)
    {
        scriptureText = text;
        hiddenWords = new List<string>();
    }

    public void DisplayScripture()
    {
        Console.WriteLine($"Scripture: {scriptureText}");
        Console.WriteLine($"Hidden Words: {string.Join(", ", hiddenWords)}");
    }

    public bool HideRandomWord()
    {
        string[] words = scriptureText.Split(new char[] { ' ', ',', '.', ';', ':', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);
        
        // Filter words to find those that are not already hidden
        List<string> visibleWords = new List<string>();
        foreach (string word in words)
        {
            if (!hiddenWords.Contains(word))
                visibleWords.Add(word);
        }
        
        if (visibleWords.Count == 0)
            return false;

        Random rnd = new Random();
        int index = rnd.Next(visibleWords.Count);
        hiddenWords.Add(visibleWords[index]);
        return true;
    }

    public bool AllWordsHidden()
    {
        return hiddenWords.Count == scriptureText.Split(new char[] { ' ', ',', '.', ';', ':', '?', '!' }, StringSplitOptions.RemoveEmptyEntries).Length;
    }
}

// Reference class to manage scripture reference details
public class Reference
{
    private string book;
    private int chapter;
    private int startVerse;
    private int endVerse;

    public Reference(string book, int chapter, int startVerse, int endVerse = 0)
    {
        this.book = book;
        this.chapter = chapter;
        this.startVerse = startVerse;
        this.endVerse = (endVerse == 0) ? startVerse : endVerse;
    }

    public string GetFullReference()
    {
        if (startVerse == endVerse)
            return $"{book} {chapter}:{startVerse}";
        else
            return $"{book} {chapter}:{startVerse}-{endVerse}";
    }

    public bool IsValidReference()
    {
        // Implement validation logic if needed
        return true;
    }
}

// Main Program class
public class Program
{
    public static void Main(string[] args)
    {
        // Example usage
        Scripture scripture = new Scripture("For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");
        Reference reference = new Reference("John", 3, 16);

        bool continueMemorizing = true;
        while (continueMemorizing)
        {
            Console.Clear();
            Console.WriteLine("Scripture Memorizer");
            Console.WriteLine("==================");
            Console.WriteLine($"Reference: {reference.GetFullReference()}");
            scripture.DisplayScripture();

            Console.WriteLine("\nPress Enter to hide a word, or type 'quit' to exit:");
            string input = Console.ReadLine().Trim().ToLower();

            if (input == "quit")
            {
                continueMemorizing = false;
            }
            else
            {
                bool wordHidden = scripture.HideRandomWord();
                if (!wordHidden)
                {
                    Console.WriteLine("\nAll words are hidden! Press Enter to exit.");
                    Console.ReadLine();
                    continueMemorizing = false;
                }
            }
        }

        Console.WriteLine("\nProgram ended. Press any key to exit.");
        Console.ReadKey();
    }
}
