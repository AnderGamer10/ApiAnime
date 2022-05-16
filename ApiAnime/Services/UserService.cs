using ApiAnime.Helpers;
using ApiAnime.Models;
using ApiAnime.Data;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
namespace ApiAnime.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<UserData> GetAll();
        UserData GetById(int id);
    }

    public class UserService : IUserService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications

        private readonly AppSettings _appSettings;
        private readonly ApiAnimeContext _context;
        public UserService(IOptions<AppSettings> appSettings, ApiAnimeContext context)
        {
            _appSettings = appSettings.Value;
            _context = context;
        }
        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _context.UserData.SingleOrDefault(u => u.Username == model.Username && u.Password == model.Password);

            // 1.- control null
            if (user == null) return null;
            // 2.- control db


            // autenticacion válida -> generamos jwt
            var (token, validTo) = generateJwtToken(user);

            return new AuthenticateResponse
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Token = token,
                ValidTo = validTo
            };
        }

        public IEnumerable<UserData> GetAll()
        {
            return _context.UserData;
        }

        public UserData GetById(int id)
        {
            return _context.UserData.FirstOrDefault(x => x.Id == id);
        }

        // helper methods

        private (string token, DateTime validTo) generateJwtToken(UserData user)
        {
            // generamos un token válido para 7 días
            var dias = 7;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("id", user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role),
                }),
                Expires = DateTime.UtcNow.AddDays(dias),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return (token: tokenHandler.WriteToken(token), validTo: token.ValidTo);
        }
    }
}
