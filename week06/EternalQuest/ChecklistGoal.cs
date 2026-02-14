public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _targetAmount;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points,
        int targetAmount, int bonus, int amountCompleted = 0)
        : base(name, description, points)
    {
        _targetAmount = targetAmount;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }

    public override int RecordEvent()
    {
        if (_amountCompleted < _targetAmount)
        {
            _amountCompleted++;
            if (_amountCompleted == _targetAmount)
            {
                return _points + _bonus;
            }
            return _points;
        }
        return 0;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _targetAmount;
    }

    public override string GetDetailsString()
    {
        string status = IsComplete() ? "[X]" : "[ ]";
        string progressBar = new string('#', _amountCompleted) +
                             new string('-', _targetAmount - _amountCompleted);

        return $"{status} {GetShortName()} ({GetDescription()}) -- " +
               $"Completed {_amountCompleted}/{_targetAmount} [{progressBar}]";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{GetShortName()},{GetDescription()},{_points}," +
               $"{_targetAmount},{_bonus},{_amountCompleted}";
    }
}
