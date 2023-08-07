namespace TestApp.Application.Rectangles.Queries.GetRectangles;

public class RectangleVm
{
    public CoordinateDto Point { get; set; }

    public List<RectangleDto> Rectangles{ get; set; }
}