using MoreLinq;

namespace OneHundred_Prisoners_Riddle;

public static class Statistics
{
    public static IReadOnlyCollection<IReadOnlyCollection<Box>> GetLoops(BoxCollection boxes)
    {
        var boxesMap = boxes.GetClosedBoxes().Select(boxes.OpenBoxNumber).ToDictionary(b => b.BoxNumber, b => b);
        var unseenBoxes = new HashSet<Box>(boxesMap.Values);
        var loops = new List<IReadOnlyCollection<Box>>();

        while (unseenBoxes.Any())
        {
            loops.Add(GetLoop(boxesMap, unseenBoxes.First(), new List<Box>(), unseenBoxes));
        }

        return loops;
    }

    private static IReadOnlyCollection<Box> GetLoop(
        IReadOnlyDictionary<int, Box> boxes,
        Box currentBox,
        List<Box> currentLoop,
        ICollection<Box> unseenBoxes)
    {
        if (currentLoop.Contains(currentBox))
        {
            return currentLoop;
        }

        currentLoop.Add(currentBox);
        unseenBoxes.Remove(currentBox);

        return GetLoop(boxes, boxes[currentBox.SlipNumber], currentLoop, unseenBoxes);
    }
}