using Api_Disney.Data;
using Api_Disney.DTOs;
using Api_Disney.Models;
using Api_Disney.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api_Disney.Services
{
    public class UsersServices : IUsersServices
    {
        private readonly IConfiguration _config;
        private readonly DbDisneyContext _context;
        public UsersServices(IConfiguration config, DbDisneyContext context)
        {
            _config = config;
            _context = context;
        }

        public User Authenticate(LoginDTO userLogin)
        {
            // Buscar el usuario por su email
            var currentUser = _context.Users.FirstOrDefault(user => user.Email.ToLower() == userLogin.Email.ToLower());

            // Si no se encuentra el usuario, retornar null
            if (currentUser == null)
            {
                return null;
            }

            // Usar PasswordHasher para verificar la contraseña
            var hasher = new PasswordHasher<User>();
            var passwordVerificationResult = hasher.VerifyHashedPassword(currentUser, currentUser.Password, userLogin.Password);

            // Si la verificación es exitosa, retornar el usuario
            if (passwordVerificationResult == PasswordVerificationResult.Success)
            {
                return currentUser;
            }

            // Si la verificación falla, retornar null
            return null;
        }


        public string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Crear los claims
            //var claims = new[]
            //{
            //new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            //new Claim(ClaimTypes.Name, user.Nombre),
            //new Claim(ClaimTypes.Email, user.Email),
            //new Claim(ClaimTypes.Surname, user.Apellido),
            //new Claim(ClaimTypes.Role, user.Rol),
            //};
            var claims = new[]
  {
        new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),  // "sub"
        new Claim(JwtRegisteredClaimNames.Name, user.Nombre),        // "name"
        new Claim(JwtRegisteredClaimNames.Email, user.Email),        // "email"
        new Claim("surname", user.Apellido),                         // Surname personalizado
        new Claim("role", user.Rol)                                  // Rol personalizado
    };

            // Crear el token
            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }



        // Método para registrar un nuevo usuario
        public async Task<User> RegisterUser(RegisterDTO registerDto)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Email.ToLower() == registerDto.Email.ToLower());

            if (existingUser != null)
            {
                throw new Exception("El correo electrónico ya está registrado.");
            }

            var hasher = new PasswordHasher<User>();

            var user = new User
            {
       
                Nombre = registerDto.Nombre,
                Apellido = registerDto.Apellido,
                Email = registerDto.Email,
                Password = hasher.HashPassword(null, registerDto.Password),  // Hash de la contraseña
                Rol = "Usuario"  // Asignación de un rol predeterminado
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}
