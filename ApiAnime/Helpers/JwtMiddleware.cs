using ApiAnime.Data;
using ApiAnime.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApiAnime.Helpers
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context, IUserService userService)
        {
            // ====> Request ===>
            string[] authoData = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ");
            if (authoData != null && authoData.Length == 2)
                if (authoData[0] == "Bearer")
                    attachUserToContext(context, userService, authoData[1]);
            // ===
            await _next(context);
            // ===
            // <=== Response <===

        }

        private void attachUserToContext(HttpContext context, IUserService userService, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);
                // a estas altura, si el token no es válido ya ha saltado el error
                // así que suponemos que el jwt ha sido validado
                var jwtToken = (JwtSecurityToken)validatedToken;

                // Colocamos user en el Contexto de la Request 
                var userId = jwtToken.Claims.First(x => x.Type == "Username").Value;
                Console.WriteLine(userId);
                context.Items["User"] = userService.GetByUsername(userId);
                var role = int.Parse(jwtToken.Claims.First(x => x.Type == ClaimTypes.Role).Value);
                context.Items["Role"] = role;

                // var userName = int.Parse(jwtToken.Claims.First(x => x.Type == ClaimTypes.Name).Value);
                // context.Items["User"] = userName;
            }
            catch
            {
                // do nothing if jwt validation fails
                // user is not attached to context so request won't have access to secure routes
            }
        }
    }
}
