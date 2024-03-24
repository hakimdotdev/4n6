using AutoRecon.Domain.Entities;

public interface IUserContext{
    string UserId { get; }
    User User { get; }
}