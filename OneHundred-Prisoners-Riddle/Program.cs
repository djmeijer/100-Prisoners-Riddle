using System.Collections.Concurrent;
using System.Diagnostics;
using ConsoleTables;
using MoreLinq;
using OneHundred_Prisoners_Riddle;
using OneHundred_Prisoners_Riddle.FirstPersonStrategy;
using OneHundred_Prisoners_Riddle.GroupStrategy;

const int numberOfIterations = 2000;
var numberOfPrisoners = new[] { 100, 200 };
var groupStrategies = new Func<IGroupStrategy>[] { () => new CheatingGroupStrategy(), () => new FirstClosedBoxGroupStrategy(), () => new CircleGroupStrategy() };
var firstPersonStrategies = new IFirstPersonStrategy[] { new DoNothingFirstPersonStrategy(), new RandomFirstPersonStrategy(), new BreakLongestCircleFirstPersonStrategy() };
var runs = numberOfPrisoners.Cartesian(groupStrategies, firstPersonStrategies, (n, g, f) => new RunInfo(n, g, f));
var table = new ConsoleTable("Number of prisoners", "Group strategy", "First person strategy", "Survival probability", "Iterations", "Time to compute (ms)");
var results = new ConcurrentBag<Result>();

var t = new Stopwatch();
t.Start();

Parallel
    .ForEach(runs, new ParallelOptions { MaxDegreeOfParallelism = 8 }, (r, _, _) =>
    {
        var result = new Solver()
            .SetNumberOfPrisoners(r.NumberOfPrisoners)
            .SetFirstPersonStrategy(r.FirstPersonStrategy)
            .SetGroupStrategy(r.GroupStrategy)
            .SetRepeats(numberOfIterations)
            .SetDebug(false)
            .Solve();
        results.Add(result);
    });

results
    .OrderBy(r => r.NumberOfPrisoners)
    .ThenBy(r => r.GroupStrategy)
    .ThenBy(r => r.FirstPersonStrategy)
    .ForEach(r => table.AddRow(r.NumberOfPrisoners, r.GroupStrategy, r.FirstPersonStrategy, $"{r.SurvivalProbability:P2}", numberOfIterations, r.ElapsedMilliseconds));

t.Stop();
Console.WriteLine(t.ElapsedMilliseconds);

table.Write(Format.MarkDown);