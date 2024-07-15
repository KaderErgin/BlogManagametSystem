using NArchitecture.Core.Application.Dtos;

namespace Application.Features.BlogPosts.Queries.GetList;

public class GetListBlogPostListItemDto : IDto
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Contents { get; set; }
    public Guid UserId { get; set; }
    public DateTime ReleaseDate { get; set; }
}