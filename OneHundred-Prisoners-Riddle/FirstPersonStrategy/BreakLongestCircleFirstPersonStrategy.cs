using MoreLinq;

namespace OneHundred_Prisoners_Riddle.FirstPersonStrategy;

public class BreakLongestCircleFirstPersonStrategy : IFirstPersonStrategy
{
    public BoxCollection Execute(BoxCollection boxes)
    {
        var loops = Statistics.GetLoops(boxes).OrderByDescending(l => l.Count).ToArray();
        var longestLoop = loops.First();
        var otherLoops = loops.Skip(1);
        var firstPart = longestLoop.Take(longestLoop.Count / 2).ToArray();
        var secondPart = longestLoop.Skip(firstPart.Length).ToArray();
        var newBoxes = new List<Box>();

        // Process first part
        firstPart.Take(firstPart.Length - 1).ForEach(b => newBoxes.Add(b));
        newBoxes.Add(new Box(firstPart.Last().BoxNumber, firstPart.First().BoxNumber));

        // Process second part
        secondPart.Take(secondPart.Length - 1).ForEach(b => newBoxes.Add(b));
        newBoxes.Add(new Box(secondPart.Last().BoxNumber, secondPart.First().BoxNumber));

        // Take the rest as is
        otherLoops.ForEach(b => newBoxes.AddRange(b));

        return new BoxCollection(newBoxes);
    }

    public string Name => "Break the longest circle";
}