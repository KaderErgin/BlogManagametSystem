using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CommentRepository : EfRepositoryBase<Comment, Guid, BaseDbContext>, ICommentRepository
{
    public CommentRepository(BaseDbContext context) : base(context)
    {
    }
}