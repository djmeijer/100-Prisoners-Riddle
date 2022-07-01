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

runs.ForEach(r =>
{
    var result = new Solver()
        .SetNumberOfPrisoners(r.NumberOfPrisoners)
        .SetFirstPersonStrategy(r.FirstPersonStrategy)
        .SetGroupStrategy(r.GroupStrategy)
        .SetRepeats(2000)
        .SetDebug(false)
        .Solve();
    
    table.AddRow(r.NumberOfPrisoners, r.GroupStrategy().Name, r.FirstPersonStrategy.Name, $"{result.SurvivalProbability:P2}", numberOfIterations, result.ElapsedMilliseconds);
});

table.Write(Format.Minimal);