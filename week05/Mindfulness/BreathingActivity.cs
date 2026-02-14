using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing",
        "This activity helps you relax by guiding your breathing slowly.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine("\nBreathe in...");
            BreatheInAnimation();

            Console.WriteLine("Breathe out...");
            BreatheOutAnimation();
        }

        DisplayEndingMessage();
    }

    private void BreatheInAnimation()
    {
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine(new string('*', i));
            Thread.Sleep(400);
        }
    }

    private void BreatheOutAnimation()
    {
        for (int i = 5; i >= 1; i--)
        {
            Console.WriteLine(new string('*', i));
            Thread.Sleep(400);
        }
    }
}
