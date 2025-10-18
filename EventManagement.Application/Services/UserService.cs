using AutoMapper;
using EventManagement.Application.DTOs;
using EventManagement.Application.Interfaces;
using EventManagement.Domain.Entities;
using EventManagement.Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using BCrypt.Net;


namespace EventManagement.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, IMapper mapper, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<bool> CreateUserAsync(CreateUserDTO dto)
        {
            try
            {
                var user = _mapper.Map<User>(dto);
                user.password_hash = BCrypt.Net.BCrypt.HashPassword(dto.Password);
                await _userRepository.AddAsync(user);
                await _userRepository.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("UserService: Error creating user", ex.Message);
                throw new Exception("Failed to create user");
            }

        }

        public Task<UserDTO> GetUserByEmailAsync(string email)
        {
            try
            {
                var user = _userRepository.GetByEmailAsync(email);
                var userDto = _mapper.Map<UserDTO>(user);
                return Task.FromResult(userDto);
            }
            catch (Exception ex)
            {
                _logger.LogError("UserService: Error retrieving user by email", ex.Message);
                throw new Exception("Failed to retrieve user");
            }
        }

        public async Task<bool> VerifyUserCredentialsAsync(LoginRequest request)
        {
            try
            {
                request.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.PasswordHash);
                var isValid = await _userRepository.VerifyCredentialsAsync(request.Email, request.PasswordHash);
                if (!isValid)
                {
                    throw new Exception("Invalid credentials");
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("UserService: Error verifying user credentials", ex.Message);
                throw new Exception("Failed to verify user credentials");
            }
        }
    }
}