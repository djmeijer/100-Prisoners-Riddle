namespace OneHundred_Prisoners_Riddle.GroupStrategy;

public class CircleGroupStrategy : IGroupStrategy
{
    private int _nextBoxNumber;

    public CircleGroupStrategy() => Reset();

    public void Execute(int prisonerNumber, BoxCollection boxes)
    {
        // Start at prisoner number. The next round, take the previously found slip number as box number.
        var aboutToOpenBoxNumber = _nextBoxNumber == -1 ? prisonerNumber : _nextBoxNumber;
        // When the box number we are about to open is already open, take a random other closed box.
        var toOpenBoxNumber = boxes.HasBoxNumberBeenOpened(aboutToOpenBoxNumber) ? boxes.GetClosedBoxNumber() : aboutToOpenBoxNumber;
        var currentBox = boxes.OpenBoxNumber(toOpenBoxNumber);
        _nextBoxNumber = currentBox.SlipNumber;   
    }

    public void Reset() => _nextBoxNumber = -1;

    public string Name => "Best strategy: follow the slips";
}