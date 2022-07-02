using MoreLinq.Extensions;

namespace OneHundred_Prisoners_Riddle;

public class BoxCollection
{
    private readonly Dictionary<int, Box> _boxes;
    private HashSet<int> _closedBoxes;
    private readonly HashSet<int> _seenSlipNumbers;

    public BoxCollection(IReadOnlyCollection<Box> boxes)
    {
        _boxes = new Dictionary<int, Box>(boxes.Count);
        _closedBoxes = new HashSet<int>(boxes.Count / 2);
        _seenSlipNumbers = new HashSet<int>(boxes.Count / 2);

        boxes.ForEach(b =>
        {
            _boxes[b.BoxNumber] = b;
            _closedBoxes.Add(b.BoxNumber);
        });
    }

    public Box OpenBoxNumber(int boxNumber)
    {
        var box = _boxes[boxNumber];
        _closedBoxes.Remove(boxNumber);
        _seenSlipNumbers.Add(box.SlipNumber);

        return box;
    }

    public IReadOnlyDictionary<int, Box> GetBoxes() => _boxes;

    public HashSet<int> GetClosedBoxes() => _closedBoxes;

    public HashSet<int> GetSeenSlipNumbers() => _seenSlipNumbers;

    public void Reset()
    {
        _boxes.Keys.ForEach(b => _closedBoxes.Add(b));
        _seenSlipNumbers.Clear();
    }
}