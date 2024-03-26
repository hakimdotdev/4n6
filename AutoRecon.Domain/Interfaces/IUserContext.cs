using AutoRecon.Domain.Entities;

namespace AutoRecon.Domain.Interfaces;

public interface IUserContext
{
    string UserId { get; }
    User User { get; }
}