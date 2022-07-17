using System.Collections.Concurrent;
using System.Diagnostics;
using System.Globalization;
using ConsoleTables;
using MoreLinq;
using OneHundred_Prisoners_Riddle;
using OneHundred_Prisoners_Riddle.FirstPersonStrategy;
using OneHundred_Prisoners_Riddle.GroupStrategy;

Thread.CurrentThread.CurrentCulture = new CultureInfo("nl-NL");

const int numberOfIterations = 20000;
var numberOfPrisoners = new[] { 20, 100, 200 };
var groupStrategies = new Func<IGroupStrategy>[] { () => new CheatingGroupStrategy(), () => new FirstClosedBoxGroupStrategy(), () => new CircleGroupStrategy() };
var firstPrisonerStrategies = new IFirstPrisonerStrategy[] { new DoNothingFirstPrisonerStrategy(), new RandomFirstPrisonerStrategy(), new BreakLongestCircleFirstPrisonerStrategy() };
var runs = numberOfPrisoners.Cartesian(groupStrategies, firstPrisonerStrategies, (n, g, f) => new RunInfo(n, g, f));
var table = new ConsoleTable("Iterations", "Number of prisoners", "Group strategy", "First person strategy", "Found survival probability", "Theoretical probability", "Time to compute (ms)");
var results = new ConcurrentBag<Result>();
var totalTimer = new Stopwatch();
totalTimer.Start();

Parallel
    .ForEach(runs, (r, _, _) =>
    {
        var result = new Solver()
            .SetNumberOfPrisoners(r.NumberOfPrisoners)
            .SetFirstPersonStrategy(r.FirstPrisonerStrategy)
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
    .ForEach(r => table.AddRow($"{numberOfIterations:N0}", r.NumberOfPrisoners, r.GroupStrategy, r.FirstPersonStrategy,
        $"{r.SurvivalProbability:P2}", $"{Statistics.GetTheoreticalProbability(r):P2}",
        $"{r.ElapsedMilliseconds:N0}"));

totalTimer.Stop();
table.Write(Format.MarkDown);
Console.WriteLine($"Took {totalTimer.ElapsedMilliseconds:N0} ms in total to compute all runs.");