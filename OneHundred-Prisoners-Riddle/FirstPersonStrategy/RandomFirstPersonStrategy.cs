using MoreLinq;

namespace OneHundred_Prisoners_Riddle.FirstPersonStrategy;

public class RandomFirstPersonStrategy : IFirstPersonStrategy
{
    public BoxCollection Execute(BoxCollection boxes)
    {
        var randomBoxes = boxes.GetClosedBoxes().Select(boxes.OpenBoxNumber).Shuffle().ToArray();
        var newBoxes = new List<Box>
        {
            // Do the exchange.
            new(randomBoxes.First().BoxNumber, randomBoxes.Skip(1).First().SlipNumber),
            new(randomBoxes.Skip(1).First().BoxNumber, randomBoxes.First().SlipNumber)
        };

        // Add the rest.
        randomBoxes.Skip(2).ForEach(b => newBoxes.Add(b));

        return new BoxCollection(newBoxes);
    }

    public string Name => "Open 2 random boxes, exchange flips";
}