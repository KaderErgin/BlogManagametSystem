using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Users.Queries.GetList;

public class GetListUserListItemDto : IDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
  

    public GetListUserListItemDto()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        Email = string.Empty;
       
    }

    public GetListUserListItemDto(Guid id, string firstName, string lastName, string email)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
      
    }
}
