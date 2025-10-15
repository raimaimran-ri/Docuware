using EventManagement.Domain.Entities;

namespace EventManagement.Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
    }
}