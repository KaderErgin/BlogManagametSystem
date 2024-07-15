using FluentValidation;

namespace Application.Features.BlogPosts.Commands.Update;

public class UpdateBlogPostCommandValidator : AbstractValidator<UpdateBlogPostCommand>
{
    public UpdateBlogPostCommandValidator()
    {
        //RuleFor(c => c.Id).NotEmpty();
        //RuleFor(c => c.Title).NotEmpty();
        //RuleFor(c => c.Contents).NotEmpty();
        //RuleFor(c => c.UserId).NotEmpty();
        //RuleFor(c => c.ReleaseDate).NotEmpty();
    }
}