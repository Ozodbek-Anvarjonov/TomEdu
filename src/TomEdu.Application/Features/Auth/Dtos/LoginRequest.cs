﻿namespace TomEdu.Application.Features.Auth.Dtos;

public class LoginRequest
{
    public string PhoneNumber { get; set; }

    public string Password { get; set; } = default!;
}