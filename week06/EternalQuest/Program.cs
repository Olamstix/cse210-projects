/*
EXCEEDING REQUIREMENTS:
1. Added Level System (every 1000 points).
2. Added Achievement Badges.
3. Added NegativeGoal type (lose points).
4. Added Progress Bar for ChecklistGoal.
*/

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
