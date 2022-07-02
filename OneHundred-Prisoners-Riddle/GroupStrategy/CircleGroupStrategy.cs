namespace OneHundred_Prisoners_Riddle.GroupStrategy;

public class CircleGroupStrategy : IGroupStrategy
{
    private int _nextBoxNumber;

    public CircleGroupStrategy() => Reset();

    public void Execute(int prisonerNumber, BoxCollection boxes)
    {
        // Start at prisoner number. The next round, take the previously found slip number as box number.
        var aboutToOpenBoxNumber = _nextBoxNumber == -1 ? prisonerNumber : _nextBoxNumber;
        var closedBoxNumbers = boxes.GetClosedBoxes();
        // When the box number we are about to open is already open, take a random other closed box.
        var toOpenBoxNumber = closedBoxNumbers.Contains(aboutToOpenBoxNumber) ? aboutToOpenBoxNumber : closedBoxNumbers.First();
        var currentBox = boxes.OpenBoxNumber(toOpenBoxNumber);
        _nextBoxNumber = currentBox.SlipNumber;   
    }

    public void Reset() => _nextBoxNumber = -1;

    public string Name => "Best strategy: follow the slips";
}