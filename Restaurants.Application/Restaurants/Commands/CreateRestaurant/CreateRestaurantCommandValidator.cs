using FluentValidation;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant;

public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
{
    private readonly List<string> categories = ["Italian", "Chinese", "Indian", "Mexican", "American", "French", "Japanese", "Mediterranean"];

    public CreateRestaurantCommandValidator()
    {

        RuleFor(dto => dto.Name)
            .NotEmpty()
            .Length(3, 100);

        RuleFor(dto => dto.Description)
            .NotEmpty().WithMessage("Description is Required.");

        RuleFor(dto => dto.Category)
            .Must(categories.Contains!)
            .WithMessage("Invalid Category. Please choose from the valid categories.");
        //.Custom((value, context) =>
        //{
        //    bool isValidCategory = categories.Contains(item: value);

        //    if (!isValidCategory)
        //    {
        //        context.AddFailure("Category", "Invalid Category. Please choose from the valid categories");
        //    }
        //});


        RuleFor(dto => dto.ContactEmail)
            .EmailAddress().WithMessage("Please provide a valid email address.");

        RuleFor(dto => dto.PostalCode)
            .Matches(@"^\d{2}-\d{3}$").WithMessage("Please provide a valid postal code (XX-XXX).");


    }
}
