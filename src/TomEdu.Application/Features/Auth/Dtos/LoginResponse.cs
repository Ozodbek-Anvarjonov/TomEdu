namespace TomEdu.Application.Features.Auth.Dtos;

public class LoginResponse
{
    public string AccessToken { get; set; } = default!;

    public string RefreshToken { get; set; } = default!;
}