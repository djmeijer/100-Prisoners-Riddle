using MoreLinq.Extensions;

namespace OneHundred_Prisoners_Riddle;

public class BoxCollection
{
    private readonly Dictionary<int, Box> _boxes;
    private readonly Dictionary<int, Box> _closedBoxes;
    private readonly LinkedList<int> _closedBoxNumbers;
    private readonly Dictionary<int, Box> _openBoxes;
    private readonly HashSet<int> _seenSlipNumbers;

    public BoxCollection(IReadOnlyCollection<Box> boxes)
    {
        _boxes = new Dictionary<int, Box>(boxes.Count);
        _closedBoxes = new Dictionary<int, Box>(boxes.Count);
        _openBoxes = new Dictionary<int, Box>(boxes.Count);
        _seenSlipNumbers = new HashSet<int>(boxes.Count);

        boxes.ForEach(b =>
        {
            _boxes[b.BoxNumber] = b;
            _closedBoxes[b.BoxNumber] = b;
        });
        _closedBoxNumbers = new LinkedList<int>(_closedBoxes.Keys);
    }

    public Box OpenBoxNumber(int boxNumber)
    {
        var box = _boxes[boxNumber];
        _closedBoxes.Remove(boxNumber);
        _openBoxes.Add(boxNumber, box);
        _seenSlipNumbers.Add(box.SlipNumber);
        _closedBoxNumbers.Remove(boxNumber);

        return box;
    }

    public IReadOnlyDictionary<int, Box> GetBoxes() => _boxes;

    public int GetClosedBoxNumber() => _closedBoxNumbers.First!.Value;

    public bool HasBoxNumberBeenOpened(int boxNumber) => _openBoxes.ContainsKey(boxNumber);

    public HashSet<int> GetSeenSlipNumbers() => _seenSlipNumbers;

    public void Reset()
    {
        _openBoxes.ForEach(b =>
        {
            _closedBoxes[b.Key] = b.Value;
            _closedBoxNumbers.AddLast(b.Key);
        });
        _openBoxes.Clear();
        _seenSlipNumbers.Clear();
    }
}