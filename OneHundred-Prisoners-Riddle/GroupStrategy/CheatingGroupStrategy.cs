using MoreLinq;

namespace OneHundred_Prisoners_Riddle.GroupStrategy;

public class CheatingGroupStrategy : IGroupStrategy
{
    public void Execute(int prisonerNumber, BoxCollection boxes)
    {
        boxes
            .GetClosedBoxes()
            .ForEach(b => boxes.OpenBoxNumber(b));
    }

    public void Reset()
    {
    }

    public string Name => "Cheating strategy: open all boxes";
}