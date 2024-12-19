using FluentValidation;
using MovieStoreTISAI.Models.Requests;

namespace MovieStoreTISAI.Validator
{
    internal class MovieValidator : AbstractValidator<AddMovieRequest>
    {
        public MovieValidator() {
            RuleFor(AddMovieRequest => AddMovieRequest.Title)
                  .NotNull();

            RuleFor(AddMovieRequest => AddMovieRequest.Year)
                 .NotNull()
                 .LessThan(3000)
                 .GreaterThan(1900);
            RuleFor(AddMovieRequest => AddMovieRequest.Actors)
                 .NotNull()
                 .NotEmpty();

        }        
    }
}
