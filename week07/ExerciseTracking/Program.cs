using System;
using System.Collections.Generic;

// Base class
public abstract class Activity
{
    private string _date;
    private int _lengthMinutes;

    public Activity(string date, int lengthMinutes)
    {
        _date = date;
        _lengthMinutes = lengthMinutes;
    }

    public string Date { get { return _date; } }
    public int LengthMinutes { get { return _lengthMinutes; } }

    // Abstract methods to be implemented by derived classes
    public abstract double GetDistance(); // miles
    public abstract double GetSpeed();    // mph
    public abstract double GetPace();     // min per mile

    // Summary using other methods
    public virtual string GetSummary()
    {
        return $"{Date} {this.GetType().Name} ({LengthMinutes} min) - Distance {GetDistance():F1} miles, Speed {GetSpeed():F1} mph, Pace: {GetPace():F2} min per mile";
    }
}

// Derived class for Running
public class Running : Activity
{
    private double _distance; // miles

    public Running(string date, int lengthMinutes, double distance)
        : base(date, lengthMinutes)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return (_distance / LengthMinutes) * 60;
    }

    public override double GetPace()
    {
        return LengthMinutes / _distance;
    }
}

// Derived class for Cycling
public class Cycling : Activity
{
    private double _speed; // mph

    public Cycling(string date, int lengthMinutes, double speed)
        : base(date, lengthMinutes)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        return (_speed * LengthMinutes) / 60;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return 60 / _speed;
    }
}

// Derived class for Swimming
public class Swimming : Activity
{
    private int _laps;
    private const double LapLengthMeters = 50;
    private const double MetersToMiles = 0.000621371;

    public Swimming(string date, int lengthMinutes, int laps)
        : base(date, lengthMinutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * LapLengthMeters * MetersToMiles;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / LengthMinutes) * 60;
    }

    public override double GetPace()
    {
        return LengthMinutes / GetDistance();
    }
}

// Main Program
class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>();

        // Create one activity of each type
        activities.Add(new Running("03 Nov 2022", 30, 3.0));
        activities.Add(new Cycling("03 Nov 2022", 45, 12.0));
        activities.Add(new Swimming("03 Nov 2022", 60, 40));

        // Display summaries
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
