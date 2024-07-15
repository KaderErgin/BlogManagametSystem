using NArchitecture.Core.Application.Responses;

namespace Application.Features.Comments.Commands.Update;

public class UpdatedCommentResponse : IResponse
{
    public Guid? Id { get; set; }
    public Guid? BlogPostId { get; set; }
    public Guid? UserId { get; set; }
    public string? CommentContent { get; set; }
    public DateTime? CommentDate { get; set; }
}