using System.Diagnostics;
using MoreLinq;
using OneHundred_Prisoners_Riddle.FirstPersonStrategy;
using OneHundred_Prisoners_Riddle.GroupStrategy;

namespace OneHundred_Prisoners_Riddle;

public class Solver
{
    private int _numberOfPrisoners;
    private Func<IGroupStrategy> _groupsStrategyCreator;
    private IFirstPersonStrategy _firstPersonStrategy;
    private int _repeats;
    private bool _debug;

    public Solver SetNumberOfPrisoners(int numberOfPrisoners)
    {
        if (numberOfPrisoners % 2 != 0)
        {
            throw new NotSupportedException("Number of prisoners must be even.");
        }

        _numberOfPrisoners = numberOfPrisoners;

        return this;
    }

    public Solver SetFirstPersonStrategy(IFirstPersonStrategy firstPersonStrategy)
    {
        _firstPersonStrategy = firstPersonStrategy;

        return this;
    }

    public Solver SetGroupStrategy(Func<IGroupStrategy> strategyCreator)
    {
        _groupsStrategyCreator = strategyCreator;

        return this;
    }

    public Solver SetRepeats(int repeats)
    {
        _repeats = repeats;

        return this;
    }

    public Solver SetDebug(bool debug)
    {
        _debug = debug;

        return this;
    }

    public Result Solve()
    {
        var totalRepeatsWithSuccess = 0;
        var maximumNumberOfSteps = _numberOfPrisoners / 2;

        var timer = new Stopwatch();
        timer.Start();

        // totalRepeatsWithSuccess = SolveParallel(maximumNumberOfSteps);
        totalRepeatsWithSuccess = SolveSequential(maximumNumberOfSteps);

        timer.Stop();

        return new Result(_numberOfPrisoners, _groupsStrategyCreator().Name, _firstPersonStrategy.Name, (decimal)totalRepeatsWithSuccess / _repeats, _repeats, timer.ElapsedMilliseconds);
    }

    private int SolveSequential(int maximumNumberOfSteps)
    {
        var totalRepeatsWithSuccess = 0;
        SolveBatch(_repeats, () => totalRepeatsWithSuccess++, maximumNumberOfSteps);

        return totalRepeatsWithSuccess;
    }

    private int SolveParallel(int maximumNumberOfSteps)
    {
        var totalRepeatsWithSuccess = 0;
        const int batchSize = 500;
        var actions = Enumerable
            .Range(0, _repeats)
            .Batch(batchSize)
            .Select(b => new Action(() => SolveBatch(b.Count(), () => Interlocked.Increment(ref totalRepeatsWithSuccess), maximumNumberOfSteps)));

        Parallel.ForEach(actions, new ParallelOptions { MaxDegreeOfParallelism = 8 },a => a());

        return totalRepeatsWithSuccess;
    }

    private void SolveBatch(int batchSize, Action incrementSuccess, int maximumNumberOfSteps)
    {
        for (var r = 0; r < batchSize; r++)
        {
            SolveSingleRun(incrementSuccess, maximumNumberOfSteps);
        }
    }

    private void SolveSingleRun(Action incrementSuccess, int maximumNumberOfSteps)
    {
        // Setup
        var availableBoxNumbers = new Stack<int>(Enumerable.Range(0, _numberOfPrisoners).Shuffle());
        var availableSlipNumbers = new Stack<int>(Enumerable.Range(0, _numberOfPrisoners).Shuffle());
        var boxes = Enumerable
            .Range(0, _numberOfPrisoners)
            .Select(_ => new Box(availableBoxNumbers.Pop(), availableSlipNumbers.Pop()))
            .ToArray();
        var prisonersWhoFoundThereSlipNumber = 0;
        var strategy = _groupsStrategyCreator();

        // Now calculate and output some interesting statistics about the box/slip placement.
        var isWinningConfig = false;
        if (_debug)
        {
            var loops = Statistics.GetLoops(new BoxCollection(boxes));
            isWinningConfig = loops.All(l => l.Count <= 50);
            Console.WriteLine($"Loops {string.Join(",", loops.Select(l => l.Count))} {(isWinningConfig ? "winning" : "loosing" )}");   
        }

        // Let each prisoner execute the strategy
        var boxCollection = new BoxCollection(boxes);
        for (var p = 0; p < _numberOfPrisoners; p++)
        {
            if (p == 0)
            {
                boxCollection = _firstPersonStrategy.Execute(boxCollection);
            }
            
            for (var s = 0; s < maximumNumberOfSteps && !boxCollection.GetSeenSlipNumbers().Contains(p); s++)
            {
                strategy.Execute(p, boxCollection);
            }

            var found = boxCollection.GetSeenSlipNumbers().Contains(p);
            if (found)
            {
                prisonersWhoFoundThereSlipNumber++;
            }

            boxCollection.Reset();
            strategy.Reset();
        }

        if (_debug)
        {
            Console.WriteLine($"{isWinningConfig} {prisonersWhoFoundThereSlipNumber} {_numberOfPrisoners}");
        }

        if (prisonersWhoFoundThereSlipNumber == _numberOfPrisoners)
        {
            incrementSuccess();
        }
    }
}