using Application.Features.BlogPosts.Constants;
using Application.Features.BlogPosts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.BlogPosts.Constants.BlogPostsOperationClaims;

namespace Application.Features.BlogPosts.Queries.GetById;

public class GetByIdBlogPostQuery : IRequest<GetByIdBlogPostResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdBlogPostQueryHandler : IRequestHandler<GetByIdBlogPostQuery, GetByIdBlogPostResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly BlogPostBusinessRules _blogPostBusinessRules;

        public GetByIdBlogPostQueryHandler(IMapper mapper, IBlogPostRepository blogPostRepository, BlogPostBusinessRules blogPostBusinessRules)
        {
            _mapper = mapper;
            _blogPostRepository = blogPostRepository;
            _blogPostBusinessRules = blogPostBusinessRules;
        }

        public async Task<GetByIdBlogPostResponse> Handle(GetByIdBlogPostQuery request, CancellationToken cancellationToken)
        {
            BlogPost? blogPost = await _blogPostRepository.GetAsync(predicate: bp => bp.Id == request.Id, cancellationToken: cancellationToken);
            await _blogPostBusinessRules.BlogPostShouldExistWhenSelected(blogPost);

            GetByIdBlogPostResponse response = _mapper.Map<GetByIdBlogPostResponse>(blogPost);
            return response;
        }
    }
}