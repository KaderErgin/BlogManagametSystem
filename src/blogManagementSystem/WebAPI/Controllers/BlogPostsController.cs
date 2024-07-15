using Application.Features.BlogPosts.Commands.Create;
using Application.Features.BlogPosts.Commands.Delete;
using Application.Features.BlogPosts.Commands.Update;
using Application.Features.BlogPosts.Queries.GetById;
using Application.Features.BlogPosts.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogPostsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateBlogPostCommand createBlogPostCommand)
    {
        CreatedBlogPostResponse response = await Mediator.Send(createBlogPostCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBlogPostCommand updateBlogPostCommand)
    {
        UpdatedBlogPostResponse response = await Mediator.Send(updateBlogPostCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedBlogPostResponse response = await Mediator.Send(new DeleteBlogPostCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdBlogPostResponse response = await Mediator.Send(new GetByIdBlogPostQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBlogPostQuery getListBlogPostQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListBlogPostListItemDto> response = await Mediator.Send(getListBlogPostQuery);
        return Ok(response);
    }
}