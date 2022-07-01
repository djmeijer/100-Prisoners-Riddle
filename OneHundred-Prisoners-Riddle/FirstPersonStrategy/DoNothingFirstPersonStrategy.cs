namespace OneHundred_Prisoners_Riddle.FirstPersonStrategy;

public class DoNothingFirstPersonStrategy : IFirstPersonStrategy
{
    public BoxCollection Execute(BoxCollection boxes)
    {
        return boxes;
    }

    public string Name => "Do nothing";
}