using MoreLinq;
using OneHundred_Prisoners_Riddle.Box;

namespace OneHundred_Prisoners_Riddle.FirstPersonStrategy;

public class RandomFirstPrisonerStrategy : IFirstPrisonerStrategy
{
    public BoxCollection Execute(BoxCollection boxes)
    {
        var randomBoxNumbers = Enumerable.Range(0, boxes.GetBoxes().Count).Shuffle().Take(2).ToArray();

        return boxes.ExchangeSlips(randomBoxNumbers[0], randomBoxNumbers[1]);
    }

    public string Name => "Open 2 random boxes, exchange slips";
}