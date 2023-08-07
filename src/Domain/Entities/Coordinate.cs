namespace TestApp.Domain.Entities;

public class Coordinate
{
    public Coordinate()
    {
    }
    
    public Coordinate(int x, int y)
    {
        X = x;
        Y = y;
    }
    public int Id { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
}
