using OneHundred_Prisoners_Riddle.FirstPersonStrategy;
using OneHundred_Prisoners_Riddle.GroupStrategy;

namespace OneHundred_Prisoners_Riddle;

public record RunInfo(int NumberOfPrisoners, Func<IGroupStrategy> GroupStrategy, IFirstPersonStrategy FirstPersonStrategy);