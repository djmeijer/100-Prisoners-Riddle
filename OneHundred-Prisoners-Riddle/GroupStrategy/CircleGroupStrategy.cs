namespace OneHundred_Prisoners_Riddle.GroupStrategy;

public class CircleGroupStrategy : IGroupStrategy
{
    private int _nextBoxNumber;

    public CircleGroupStrategy() => Reset();

    public void Execute(int prisonerNumber, BoxCollection boxes)
    {
        var aboutToOpenBoxNumber = _nextBoxNumber == -1 ? prisonerNumber : _nextBoxNumber;
        var closedBoxNumbers = boxes.GetClosedBoxes();
        var currentBox = boxes.OpenBoxNumber(closedBoxNumbers.Contains(aboutToOpenBoxNumber) ? aboutToOpenBoxNumber : closedBoxNumbers.First());
        _nextBoxNumber = currentBox.SlipNumber;   
    }

    public void Reset() => _nextBoxNumber = -1;

    public string Name => "Best strategy: follow the slips";
}