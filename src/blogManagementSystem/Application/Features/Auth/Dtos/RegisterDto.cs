using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Auth.Dtos;
public class RegisterDto
{
    public UserForRegisterDto User { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
   

}
