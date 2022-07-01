namespace OneHundred_Prisoners_Riddle.FirstPersonStrategy;

public interface IFirstPersonStrategy
{
    public BoxCollection Execute(BoxCollection boxes);

    string Name { get; }
}