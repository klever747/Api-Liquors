
using Application.API.Repositories;
using Application.API.Services;
using Domain.Entities;
using Infrastructure.API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ISecurityService _securityService;
        private readonly IPasswordHasher _passwordHasher;
        public TokenController(IConfiguration configuration,ISecurityService securityService, IPasswordHasher passwordHasher)
        {
            _configuration = configuration;
            _securityService = securityService;
            _passwordHasher = passwordHasher;
        }
        [HttpPost]
        public async Task<IActionResult> Authentication(UserLogin login)
        {
            var validation = await IsValidateUser(login);
            if (validation.Item1)
            {
                var token = GenerateToken(validation.Item2);
                return Ok(new { token });
            }

            return NotFound();
        }
        private async Task<(bool,Security)> IsValidateUser(UserLogin login)
        {
            var user = await _securityService.GetLoginByCredentials(login);
            var isValid = _passwordHasher.Check(user.Passwordu, login.Password);
            return (isValid, user ); 
        } 
        private string GenerateToken(Security security)
        {
            #region Header
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);
            #endregion Header

            #region Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, security.UserName),
                new Claim("Useru", security.Users),
                new Claim(ClaimTypes.Role, security.Roleu.ToString())
            };
            #endregion Claims

            #region Payload
            var payload = new JwtPayload
            (
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddHours(24)
            );

            #endregion Payload

            var token = new JwtSecurityToken(header, payload);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
