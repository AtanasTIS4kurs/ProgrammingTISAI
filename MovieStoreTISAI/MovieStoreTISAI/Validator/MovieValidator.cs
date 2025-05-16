using FluentValidation;
using MovieStoreTISAI.Models.Requests;

namespace MovieStoreTISAI.Validator
{
    internal class MovieValidator : AbstractValidator<AddMovieRequest>
    {
        public MovieValidator()
        {
            RuleFor(x => x.Year).GreaterThan(0).WithMessage("Въведи по-голямо от 0");
            RuleFor(x => x.ActorIds).NotNull().NotEmpty();
        }
    }
}
