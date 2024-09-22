using Api_Disney.DTOs;
using Api_Disney.Models;

namespace Api_Disney.Services.Interfaces
{
    public interface IUsersServices
    {
        User Authenticate(LoginDTO userLogin);  // Autenticación de usuarios
        string GenerateToken(User user);  // Generación de JWT
        Task<User> RegisterUser(RegisterDTO registerDto);  // Registro de usuario
    }
}
