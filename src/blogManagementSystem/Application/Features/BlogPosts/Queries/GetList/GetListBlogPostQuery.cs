using Application.Features.BlogPosts.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.BlogPosts.Constants.BlogPostsOperationClaims;

namespace Application.Features.BlogPosts.Queries.GetList;

public class GetListBlogPostQuery : IRequest<GetListResponse<GetListBlogPostListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListBlogPosts({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetBlogPosts";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListBlogPostQueryHandler : IRequestHandler<GetListBlogPostQuery, GetListResponse<GetListBlogPostListItemDto>>
    {
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly IMapper _mapper;

        public GetListBlogPostQueryHandler(IBlogPostRepository blogPostRepository, IMapper mapper)
        {
            _blogPostRepository = blogPostRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListBlogPostListItemDto>> Handle(GetListBlogPostQuery request, CancellationToken cancellationToken)
        {
            IPaginate<BlogPost> blogPosts = await _blogPostRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListBlogPostListItemDto> response = _mapper.Map<GetListResponse<GetListBlogPostListItemDto>>(blogPosts);
            return response;
        }
    }
}