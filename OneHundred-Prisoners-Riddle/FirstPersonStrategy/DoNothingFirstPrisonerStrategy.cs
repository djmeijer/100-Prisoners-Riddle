using OneHundred_Prisoners_Riddle.Box;

namespace OneHundred_Prisoners_Riddle.FirstPersonStrategy;

public class DoNothingFirstPrisonerStrategy : IFirstPrisonerStrategy
{
    public BoxCollection Execute(BoxCollection boxes) => boxes;

    public string Name => "Do nothing";
}