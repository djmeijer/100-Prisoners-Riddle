namespace OneHundred_Prisoners_Riddle.GroupStrategy;

public class FirstClosedBoxGroupStrategy : IGroupStrategy
{
    public void Execute(int prisonerNumber, BoxCollection boxes)
    {
        var boxNumber = boxes.GetClosedBoxes().First();

        boxes.OpenBoxNumber(boxNumber);
    }

    public void Reset()
    {
    }

    public string Name => "Random: open the first box you see";
}