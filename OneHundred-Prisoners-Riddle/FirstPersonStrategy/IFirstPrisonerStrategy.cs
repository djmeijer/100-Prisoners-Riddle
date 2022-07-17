using OneHundred_Prisoners_Riddle.Box;

namespace OneHundred_Prisoners_Riddle.FirstPersonStrategy;

public interface IFirstPrisonerStrategy
{
    public BoxCollection Execute(BoxCollection boxes);

    string Name { get; }
}