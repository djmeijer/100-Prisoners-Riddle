namespace OneHundred_Prisoners_Riddle.GroupStrategy;

public class FirstClosedBoxGroupStrategy : IGroupStrategy
{
    public void Execute(int prisonerNumber, BoxCollection boxes)
    {
        var firstClosedBoxNumber = boxes.GetClosedBoxNumber();

        boxes.OpenBoxNumber(firstClosedBoxNumber);
    }

    public void Reset()
    {
    }

    public string Name => "First closed: open the first box you see";
}