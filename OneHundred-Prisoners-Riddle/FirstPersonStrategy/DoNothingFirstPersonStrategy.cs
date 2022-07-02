using OneHundred_Prisoners_Riddle.Box;

namespace OneHundred_Prisoners_Riddle.FirstPersonStrategy;

public class DoNothingFirstPersonStrategy : IFirstPersonStrategy
{
    public BoxCollection Execute(BoxCollection boxes) => boxes;

    public string Name => "Do nothing";
}