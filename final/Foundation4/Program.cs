using System;
using System.Collections.Generic;

// Base class for an Activity
public abstract class Activity
{
    private DateTime date;
    private int minutes;

    protected Activity(DateTime date, int minutes)
    {
        this.date = date;
        this.minutes = minutes;
    }

    public DateTime Date => date;
    public int Minutes => minutes;

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{date.ToShortDateString()} {this.GetType().Name} ({minutes} min): " +
               $"Distance: {GetDistance():0.0} km, Speed: {GetSpeed():0.0} kph, Pace: {GetPace():0.0} min per km";
    }
}

// Derived class for Running
public class Running : Activity
{
    private double distance;

    public Running(DateTime date, int minutes, double distance)
        : base(date, minutes)
    {
        this.distance = distance;
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        return (distance / Minutes) * 60;
    }

    public override double GetPace()
    {
        return Minutes / distance;
    }
}

// Derived class for Cycling
public class Cycling : Activity
{
    private double speed;

    public Cycling(DateTime date, int minutes, double speed)
        : base(date, minutes)
    {
        this.speed = speed;
    }

    public override double GetDistance()
    {
        return (speed * Minutes) / 60;
    }

    public override double GetSpeed()
    {
        return speed;
    }

    public override double GetPace()
    {
        return 60 / speed;
    }
}

// Derived class for Swimming
public class Swimming : Activity
{
    private int laps;

    public Swimming(DateTime date, int minutes, int laps)
        : base(date, minutes)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        return laps * 50 / 1000.0; // Distance in kilometers
    }

    public override double GetSpeed()
    {
        return (GetDistance() / Minutes) * 60;
    }

    public override double GetPace()
    {
        return Minutes / GetDistance();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Create activities
        Activity running = new Running(new DateTime(2023, 11, 3), 30, 4.8);
        Activity cycling = new Cycling(new DateTime(2023, 11, 4), 45, 20);
        Activity swimming = new Swimming(new DateTime(2023, 11, 5), 60, 30);

        // List of activities
        List<Activity> activities = new List<Activity> { running, cycling, swimming };

        // Display summary for each activity
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
