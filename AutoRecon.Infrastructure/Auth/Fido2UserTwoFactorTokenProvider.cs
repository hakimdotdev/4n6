﻿namespace AutoRecon.Infrastructure.Auth;

public class Fido2UserTwoFactorTokenProvider : IUserTwoFactorTokenProvider<IdentityUser>
{
    public Task<bool> CanGenerateTwoFactorTokenAsync(UserManager<IdentityUser> manager, IdentityUser user)
    {
        return Task.FromResult(true);
    }

    public Task<string> GenerateAsync(string purpose, UserManager<IdentityUser> manager, IdentityUser user)
    {
        return Task.FromResult("fido2");
    }

    public Task<bool> ValidateAsync(string purpose, string token, UserManager<IdentityUser> manager, IdentityUser user)
    {
        return Task.FromResult(true);
    }
}