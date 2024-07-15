using NArchitecture.Core.Application.Responses;

namespace Application.Features.Comments.Queries.GetById;

public class GetByIdCommentResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid BlogPostId { get; set; }
    public Guid UserId { get; set; }
    public string CommentContent { get; set; }
    public DateTime CommentDate { get; set; }
}