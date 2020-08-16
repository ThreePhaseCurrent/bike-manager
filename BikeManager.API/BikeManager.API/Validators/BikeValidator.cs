using BikeManager.API.Models;
using BikeManager.Core.Models;
using FluentValidation;

namespace BikeManager.API.Validators
{
    public class BikeDtoValidator: AbstractValidator<BikeDto>
    {
        public BikeDtoValidator()
        {
            RuleFor(x => x.BikeName).NotEmpty();
            RuleFor(x => x.CategoryName).NotEmpty();
            RuleFor(x => x.StatusName).NotEmpty();
            RuleFor(x => x.Price).NotNull();
        }
    }
}