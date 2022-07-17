using OneHundred_Prisoners_Riddle.Box;

namespace OneHundred_Prisoners_Riddle.FirstPersonStrategy;

public class BreakLongestCircleFirstPrisonerStrategy : IFirstPrisonerStrategy
{
    public BoxCollection Execute(BoxCollection boxes)
    {
        var longestLoop = Statistics.GetLoops(boxes).OrderByDescending(l => l.Count).First();
        var firstPath = longestLoop.Take(longestLoop.Count / 2).ToArray();
        var firstPartEnd = firstPath.Last();
        var secondPartEnd = longestLoop.Skip(firstPath.Length).Last();

        return boxes.ExchangeSlips(firstPartEnd.BoxNumber, secondPartEnd.BoxNumber);
    }

    public string Name => "Break the longest circle";
}