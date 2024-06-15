using System;
using System.Threading;
using System.Collections.Generic;

// Base class
public abstract class MindfulnessActivity
{
    private string name;
    private string description;
    protected int Duration;

    public MindfulnessActivity(string name, string description)
    {
        this.name = name;
        this.description = description;
    }

    public string Name
    {
        get { return name; }
    }

    public void SetDuration()
    {
        Console.Write("Enter the duration of the activity in seconds: ");
        Duration = int.Parse(Console.ReadLine());
    }

    public void StartingMessage()
    {
        Console.WriteLine($"\nStarting {Name} activity.");
        Console.WriteLine(description);
        SetDuration();
        Console.WriteLine("Get ready to begin...");
        AnimatePause(3);
    }

    public void EndingMessage()
    {
        Console.WriteLine("\nGood job!");
        Console.WriteLine($"You have completed the {Name} activity for {Duration} seconds.");
        AnimatePause(3);
    }

    public void AnimatePause(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i}... ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    public abstract void Run();
}

// Derived class for Breathing Activity
public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void Run()
    {
        StartingMessage();
        int elapsed = 0;
        while (elapsed < Duration)
        {
            Console.WriteLine("Breathe in...");
            AnimatePause(4);
            Console.WriteLine("Breathe out...");
            AnimatePause(4);
            elapsed += 8;
        }
        EndingMessage();
    }
}

// Derived class for Reflection Activity
public class ReflectionActivity : MindfulnessActivity
{
    private List<string> Prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> Questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity() : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    public override void Run()
    {
        StartingMessage();
        Random rand = new Random();
        string prompt = Prompts[rand.Next(Prompts.Count)];
        Console.WriteLine(prompt);
        int elapsed = 0;
        while (elapsed < Duration)
        {
            string question = Questions[rand.Next(Questions.Count)];
            Console.WriteLine(question);
            AnimatePause(5);
            elapsed += 10;
        }
        EndingMessage();
    }
}

// Derived class for Listing Activity
public class ListingActivity : MindfulnessActivity
{
    private List<string> Prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public override void Run()
    {
        StartingMessage();
        Random rand = new Random();
        string prompt = Prompts[rand.Next(Prompts.Count)];
        Console.WriteLine(prompt);
        AnimatePause(5);
        List<string> items = new List<string>();
        int elapsed = 0;
        while (elapsed < Duration)
        {
            Console.Write("Answer: ");
            items.Add(Console.ReadLine());
            elapsed += 2;
        }
        Console.WriteLine($"\nYou listed {items.Count} items.");
        EndingMessage();
    }
}

// Logger class for exceeding requirements
public class Logger
{
    private List<string> logEntries = new List<string>();

    public void Log(string message)
    {
        logEntries.Add($"{DateTime.Now}: {message}");
    }

    public void SaveLog(string filename)
    {
        System.IO.File.WriteAllLines(filename, logEntries);
    }

    public void LoadLog(string filename)
    {
        if (System.IO.File.Exists(filename))
        {
            logEntries = new List<string>(System.IO.File.ReadAllLines(filename));
        }
    }

    public void PrintLog()
    {
        foreach (string entry in logEntries)
        {
            Console.WriteLine(entry);
        }
    }
}

// Derived class for Meditation Activity (Exceeding Requirements)
public class MeditationActivity : MindfulnessActivity
{
    public MeditationActivity() : base("Meditation", "This activity will guide you through a meditation session to help you relax and clear your mind.")
    {
    }

    public override void Run()
    {
        StartingMessage();
        int elapsed = 0;
        while (elapsed < Duration)
        {
            Console.WriteLine("Focus on your breathing and clear your mind...");
            AnimatePause(10);
            elapsed += 10;
        }
        EndingMessage();
    }
}

// Main program
public class Program
{
    public static void Main(string[] args)
    {
        Logger logger = new Logger();
        Dictionary<string, MindfulnessActivity> activities = new Dictionary<string, MindfulnessActivity>
        {
            { "1", new BreathingActivity() },
            { "2", new ReflectionActivity() },
            { "3", new ListingActivity() },
            { "4", new MeditationActivity() }
        };

        while (true)
        {
            Console.WriteLine("\nMindfulness Program Menu");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Meditation Activity");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an activity: ");
            string choice = Console.ReadLine();
            if (choice == "5")
            {
                Console.WriteLine("Exiting the program. Take care!");
                logger.SaveLog("activity_log.txt");
                break;
            }
            else if (activities.ContainsKey(choice))
            {
                activities[choice].Run();
                logger.Log($"{activities[choice].Name} activity completed.");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please select a valid option.");
            }
        }
    }
}
