namespace TestApp.Domain.Entities;

public class Rectangle
{
    public Rectangle()
    {
    }
    public Rectangle(int topLeftX, int topLeftY, int bottomRightX, int bottomRightY)
    {
        TopLeft = new Coordinate(topLeftX, topLeftY);
        BottomRight = new Coordinate(bottomRightX, bottomRightY);
    }

    public int Id { get; set; }
    public Coordinate TopLeft { get; set; }
    public int TopLeftId { get; set; }
    public Coordinate BottomRight { get; set; }
    public int BottomRightId { get; set; }
}
