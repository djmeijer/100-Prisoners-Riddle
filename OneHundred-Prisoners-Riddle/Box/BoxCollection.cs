using MoreLinq.Extensions;

namespace OneHundred_Prisoners_Riddle.Box;

public class BoxCollection
{
    private readonly Dictionary<int, Box> _boxes;
    private readonly LinkedList<int> _closedBoxNumbers;
    private readonly Dictionary<int, Box> _openBoxes;
    private readonly HashSet<int> _seenSlipNumbers;

    public BoxCollection(IReadOnlyCollection<Box> boxes)
    {
        _boxes = new Dictionary<int, Box>(boxes.Count);
        _closedBoxNumbers = new LinkedList<int>();
        _openBoxes = new Dictionary<int, Box>(boxes.Count);
        _seenSlipNumbers = new HashSet<int>(boxes.Count);
        boxes.ForEach(b =>
        {
            _boxes[b.BoxNumber] = b;
            _closedBoxNumbers.AddLast(b.BoxNumber);
        });
    }

    public Box OpenBoxNumber(int boxNumber)
    {
        var box = _boxes[boxNumber];
        _openBoxes.Add(boxNumber, box);
        _seenSlipNumbers.Add(box.SlipNumber);
        _closedBoxNumbers.Remove(boxNumber);

        return box;
    }

    public IReadOnlyDictionary<int, Box> GetBoxes() => _boxes;

    public int GetClosedBoxNumber() => _closedBoxNumbers.First!.Value;

    public bool HasBoxNumberBeenOpened(int boxNumber) => _openBoxes.ContainsKey(boxNumber);

    public HashSet<int> GetSeenSlipNumbers() => _seenSlipNumbers;

    public BoxCollection ExchangeSlips(int firstBoxNumber, int secondBoxNumber)
    {
        var temp = _boxes[firstBoxNumber].SlipNumber;
        _boxes[firstBoxNumber] = new Box(firstBoxNumber, _boxes[secondBoxNumber].SlipNumber);
        _boxes[secondBoxNumber] = new Box(secondBoxNumber, temp);

        return this;
    }

    public void Reset()
    {
        _openBoxes.ForEach(b => _closedBoxNumbers.AddLast(b.Key));
        _openBoxes.Clear();
        _seenSlipNumbers.Clear();
    }
}