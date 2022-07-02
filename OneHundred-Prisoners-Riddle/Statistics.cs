using OneHundred_Prisoners_Riddle.Box;
using OneHundred_Prisoners_Riddle.FirstPersonStrategy;

namespace OneHundred_Prisoners_Riddle;

public static class Statistics
{
    public static IReadOnlyCollection<IReadOnlyCollection<Box.Box>> GetLoops(BoxCollection boxes)
    {
        var boxesMap = boxes.GetBoxes();
        var unseenBoxes = new HashSet<Box.Box>(boxesMap.Values);
        var loops = new List<IReadOnlyCollection<Box.Box>>();

        while (unseenBoxes.Any())
        {
            loops.Add(GetLoop(boxesMap, unseenBoxes.First(), new List<Box.Box>(), unseenBoxes));
        }

        return loops;
    }

    private static IReadOnlyCollection<Box.Box> GetLoop(IReadOnlyDictionary<int, Box.Box> boxes, Box.Box currentBox, List<Box.Box> currentLoop, ICollection<Box.Box> unseenBoxes)
    {
        while (true)
        {
            if (currentLoop.Contains(currentBox))
            {
                return currentLoop;
            }

            currentLoop.Add(currentBox);
            unseenBoxes.Remove(currentBox);

            currentBox = boxes[currentBox.SlipNumber];
        }
    }
    
    public static decimal GetTheoreticalProbability(Result result)
    {
        if (string.Equals(result.FirstPersonStrategy, new BreakLongestCircleFirstPersonStrategy().Name, StringComparison.OrdinalIgnoreCase))
        {
            return 1;
        }
    
        decimal sum = 0;
        for (var i = result.NumberOfPrisoners / 2 + 1; i <= result.NumberOfPrisoners; i++)
        {
            sum += (decimal)1 / i;
        }

        return 1 - sum;
    }

}