using Api_Disney.DTOs;
using Api_Disney.Exceptions;
using Api_Disney.Mappers;
using Api_Disney.Models;
using Api_Disney.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Api_Disney.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsersServices _services;

        public AuthController(IUsersServices services)
        {
            _services = services;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterDTO register)
        {
            try
            {
                // Registra el nuevo usuario utilizando el servicio
                var user = await _services.RegisterUser(register);

                // Envía un correo de verificación (implementa la lógica de envío de correo aquí)
                // await _emailService.SendVerificationEmail(user.Email);

                // Devuelve una respuesta de éxito sin un token
                return Ok(new { message = "Usuario registrado. Por favor verifica tu correo electrónico." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginDTO login)
        {
            // Autentica al usuario a través del servicio
            var user = _services.Authenticate(login);

            if (user == null)
            {
                return Unauthorized("Credenciales incorrectas.");
            }

            // Genera un token para el usuario autenticado
            var token = _services.GenerateToken(user);

            return Ok(new { token });
        }

    }
}
