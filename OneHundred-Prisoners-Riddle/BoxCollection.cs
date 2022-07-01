using MoreLinq.Extensions;

namespace OneHundred_Prisoners_Riddle;

public class BoxCollection
{
    private readonly Dictionary<int, Box> _boxes;
    private HashSet<int> _closedBoxes;
    private readonly HashSet<int> _closedBoxesOriginal;
    private HashSet<int> _seenSlipNumbers;

    public BoxCollection(IEnumerable<Box> boxes)
    {
        _boxes = new Dictionary<int, Box>();
        _closedBoxesOriginal = new HashSet<int>();
        _seenSlipNumbers = new HashSet<int>();

        boxes.ForEach(b =>
        {
            _boxes[b.BoxNumber] = b;
            _closedBoxesOriginal.Add(b.BoxNumber);
        });
        _closedBoxes = new HashSet<int>(_closedBoxesOriginal);
    }

    public Box OpenBoxNumber(int boxNumber)
    {
        var box = _boxes[boxNumber];
        if (_closedBoxes.Contains(boxNumber))
        {
            _closedBoxes.Remove(boxNumber);
            _seenSlipNumbers.Add(box.SlipNumber);
        }

        return box;
    }

    public HashSet<int> GetClosedBoxes() => _closedBoxes;

    public HashSet<int> GetSeenSlipNumbers() => _seenSlipNumbers;

    public void Reset()
    {
        _closedBoxes = new HashSet<int>();
        _closedBoxes = new HashSet<int>(_closedBoxesOriginal);
        _seenSlipNumbers = new HashSet<int>();
    }
}