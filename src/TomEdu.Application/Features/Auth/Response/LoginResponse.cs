namespace TomEdu.Application.Features.Auth.Response;

public class LoginResponse
{
    public string AccessToken { get; set; } = default!;

    public string RefreshToken { get; set; } = default!;
}