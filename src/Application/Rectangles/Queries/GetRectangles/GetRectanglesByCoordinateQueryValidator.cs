using FluentValidation;

namespace TestApp.Application.Rectangles.Queries.GetRectangles;

public class GetRectanglesByCoordinateQueryValidator : AbstractValidator<GetRectanglesByCoordinateQuery>
{
    public GetRectanglesByCoordinateQueryValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;
        
        RuleFor(x=> x.X)
            .GreaterThanOrEqualTo(1)
            .WithMessage("X coordinate must be greater than or equal to 1.");
        
        RuleFor(x=> x.Y)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Y coordinate must be greater than or equal to 1.");
    }
}
