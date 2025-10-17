using EventManagement.Application.DTOs;

namespace EventManagement.Application.Interfaces
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(CreateUserDTO dto);
        Task<UserDTO> GetUserByEmailAsync(string email);
        Task<bool> VerifyUserCredentialsAsync(LoginRequest request);
    }
}