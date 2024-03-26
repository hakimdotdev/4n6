using AutoRecon.Domain.Entities;

namespace AutoRecon.Application.Services;

public interface IUserContext
{
    User User { get; }
    string UserId { get; }
}