using EventManagement.Domain.Entities;

namespace EventManagement.Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task AddAsync(User user);
        Task SaveChangesAsync();
        Task<User> GetByEmailAsync(string email);
        Task<bool> VerifyCredentialsAsync(string email, string password);
        Task<bool> IsUserCreator(int userId);
        Task<bool> IsEmailUnique(string email);
    }
}