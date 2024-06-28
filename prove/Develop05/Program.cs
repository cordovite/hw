using System;
using System.Collections.Generic;

public abstract class Goal
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Points { get; protected set; }
    public bool IsComplete { get; protected set; }

    public Goal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
        IsComplete = false;
    }

    public abstract void RecordEvent();
    public abstract string GetStatus();
}

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override void RecordEvent()
    {
        IsComplete = true;
    }

    public override string GetStatus()
    {
        return IsComplete ? "[X]" : "[ ]";
    }
}

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override void RecordEvent()
    {
        // Eternal goals are never complete, they just accumulate points
    }

    public override string GetStatus()
    {
        return "[Eternal]";
    }
}

public class ChecklistGoal : Goal
{
    public int RequiredCount { get; set; }
    public int CurrentCount { get; set; }
    public int BonusPoints { get; set; }

    public ChecklistGoal(string name, string description, int points, int requiredCount, int bonusPoints)
        : base(name, description, points)
    {
        RequiredCount = requiredCount;
        CurrentCount = 0;
        BonusPoints = bonusPoints;
    }

    public override void RecordEvent()
    {
        CurrentCount++;
        if (CurrentCount >= RequiredCount)
        {
            IsComplete = true;
            Points += BonusPoints;
        }
    }

    public override string GetStatus()
    {
        return $"[{(IsComplete ? "X" : " ")}] Completed {CurrentCount}/{RequiredCount} times";
    }
}

public class EternalQuest
{
    private List<Goal> goals = new List<Goal>();
    private int totalPoints = 0;

    public void CreateGoal()
    {
        Console.WriteLine("Choose a goal type: 1) Simple, 2) Eternal, 3) Checklist");
        int choice = int.Parse(Console.ReadLine());

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();

        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();

        Console.Write("Enter goal points: ");
        int points = int.Parse(Console.ReadLine());

        Goal goal = null;

        switch (choice)
        {
            case 1:
                goal = new SimpleGoal(name, description, points);
                break;
            case 2:
                goal = new EternalGoal(name, description, points);
                break;
            case 3:
                Console.Write("Enter required count for completion: ");
                int count = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points for completion: ");
                int bonus = int.Parse(Console.ReadLine());
                goal = new ChecklistGoal(name, description, points, count, bonus);
                break;
            default:
                Console.WriteLine("Invalid choice, please try again.");
                break;
        }

        if (goal != null)
        {
            goals.Add(goal);
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("Select a goal to record an event:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].Name}");
        }
        int goalIndex = int.Parse(Console.ReadLine()) - 1;
        goals[goalIndex].RecordEvent();
        totalPoints += goals[goalIndex].Points;
    }

    public void DisplayGoals()
    {
        Console.WriteLine("Goals:");
        foreach (var goal in goals)
        {
            Console.WriteLine($"{goal.GetStatus()} {goal.Name}: {goal.Description}");
        }
        Console.WriteLine($"Total Points: {totalPoints}");
    }

    public void SaveGoals()
    {
        // For simplicity, saving to a file is omitted in this example
        Console.WriteLine("Saving goals...");
    }

    public void LoadGoals()
    {
        // For simplicity, loading from a file is omitted in this example
        Console.WriteLine("Loading goals...");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        EternalQuest quest = new EternalQuest();
        bool running = true;

        while (running)
        {
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Display Goals");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Exit");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    quest.CreateGoal();
                    break;
                case 2:
                    quest.RecordEvent();
                    break;
                case 3:
                    quest.DisplayGoals();
                    break;
                case 4:
                    quest.SaveGoals();
                    break;
                case 5:
                    quest.LoadGoals();
                    break;
                case 6:
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }
}

        
