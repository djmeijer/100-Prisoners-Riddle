using MoreLinq;

namespace OneHundred_Prisoners_Riddle.GroupStrategy;

public class CheatingGroupStrategy : IGroupStrategy
{
    public void Execute(int prisonerNumber, BoxCollection boxes)
    {
        boxes
            .GetBoxes()
            .Where(b => b.Value.SlipNumber == prisonerNumber)
            .ForEach(b => boxes.OpenBoxNumber(b.Key));
    }

    public void Reset()
    {
    }

    public string Name => "Cheating strategy: open all boxes";
}