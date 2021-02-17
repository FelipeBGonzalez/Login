using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Login.Domain.Interfaces;
using Login.Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System;

namespace Login.Domain.Service
{
    public class SignInDomain : ISignInDomain
    {
        public UserDomain Execute(string email, string password)
        {
            UserDomain ret = new UserDomain();
            ValidUser(email,password);
            ret = DomainBase.provider.GetService<IUserRepository>().Signin(email, password);
            if (ret.id != null)
            {
                ret.token = GenerateToken(ret);
                ret.last_login = DateTime.Now;
                DomainBase.provider.GetService<IUserRepository>().UpdateToken(ret);
            }

            return ret;
        }

        private string GenerateToken(UserDomain user)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("E9A975E3-F262-4DB2-8D8E-87DD644615BA"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Sid, user.id),
                    new Claim(ClaimTypes.Name, user.firstName),
                    new Claim(ClaimTypes.Email, user.email),
                    new Claim(ClaimTypes.NameIdentifier, user.email)
                };

            var tokenOptions = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(2),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return tokenString;
        }

        public void ValidUser(string email, string password)
        {
            ErrorDomain ret = new ErrorDomain();

            if (DomainBase.provider.GetService<IUserRepository>().Signin(email, password).id == null)
            {
                throw new ArgumentException("Invalid e-mail or password", "3");
            }

            if (string.IsNullOrEmpty(email) ||  string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Missing Filds", "2");
            }
        }
    }
}
