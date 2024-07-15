using Application.Features.BlogPosts.Constants;
using Application.Features.BlogPosts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.BlogPosts.Constants.BlogPostsOperationClaims;

namespace Application.Features.BlogPosts.Commands.Create;

public class CreateBlogPostCommand : IRequest<CreatedBlogPostResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public string? Title { get; set; }
    public string? Contents { get; set; }
    public Guid UserId { get; set; }
    public DateTime ReleaseDate { get; set; }

    public string[] Roles => [Admin, Write, BlogPostsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetBlogPosts"];

    public class CreateBlogPostCommandHandler : IRequestHandler<CreateBlogPostCommand, CreatedBlogPostResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly BlogPostBusinessRules _blogPostBusinessRules;

        public CreateBlogPostCommandHandler(IMapper mapper, IBlogPostRepository blogPostRepository,
                                         BlogPostBusinessRules blogPostBusinessRules)
        {
            _mapper = mapper;
            _blogPostRepository = blogPostRepository;
            _blogPostBusinessRules = blogPostBusinessRules;
        }

        public async Task<CreatedBlogPostResponse> Handle(CreateBlogPostCommand request, CancellationToken cancellationToken)
        {
            BlogPost blogPost = _mapper.Map<BlogPost>(request);

            await _blogPostRepository.AddAsync(blogPost);

            CreatedBlogPostResponse response = _mapper.Map<CreatedBlogPostResponse>(blogPost);
            return response;
        }
    }
}