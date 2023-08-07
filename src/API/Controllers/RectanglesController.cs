using Microsoft.AspNetCore.Mvc;
using TestApp.Application.Rectangles.Queries.GetRectangles;

namespace API.Controllers;

public class RectanglesController : ApiControllerBase
{
    [HttpGet("by-coordinate")]
    public async Task<ActionResult<List<RectangleDto>>> GetRectanglesByCoordinate([FromQuery] GetRectanglesByCoordinateQuery query)
    {
        return await Mediator.Send(query);
    }

    // Test request
//     {
//     "coordinates": [
//     {
//         "x": 100,
//         "y": 100
//     },
//     {
//         "x": 200,
//         "y": 200
//     },
//     {
//         "x": 300,
//         "y": 300
//     }
//     ]
//      }'
    [HttpPost("by-coordinates")]
    public async Task<ActionResult<List<RectangleVm>>> GetRectanglesByCoordinate([FromBody]GetRectanglesByMultipleCoordinateQuery query)
    {
        return await Mediator.Send(query);
    }
    
    [HttpGet("all")]
    public async Task<ActionResult<List<RectangleDto>>> GetRectangles()
    {
        return await Mediator.Send(new GetRectanglesQuery());
    }
}
