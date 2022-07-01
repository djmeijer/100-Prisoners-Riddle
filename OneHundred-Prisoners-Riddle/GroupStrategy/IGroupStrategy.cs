namespace OneHundred_Prisoners_Riddle.GroupStrategy;

public interface IGroupStrategy
{
    public void Execute(int prisonerNumber, BoxCollection boxes);

    void Reset();

    string Name { get; }
}