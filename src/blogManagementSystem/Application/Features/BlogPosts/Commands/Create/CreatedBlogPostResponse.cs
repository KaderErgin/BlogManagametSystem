using NArchitecture.Core.Application.Responses;

namespace Application.Features.BlogPosts.Commands.Create;

public class CreatedBlogPostResponse : IResponse
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Contents { get; set; }
    public Guid UserId { get; set; }
    public DateTime ReleaseDate { get; set; }
}