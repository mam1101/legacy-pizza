using API.Models;
using FluentValidation;

namespace API.Validation;

public class PizzaValidator : AbstractValidator<Pizza>
{
    public PizzaValidator()
    {
        RuleFor(model => model.Name).NotEmpty();
        RuleFor(model => model.Description).NotEmpty();
    }
}