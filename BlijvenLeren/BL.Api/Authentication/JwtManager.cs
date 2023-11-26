using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BL.Api.Authentication
{
    public class JwtManager : IJwtManager
    {
        //Dit komt normaal uit een database natuurlijk
        private readonly IDictionary<string, string> users = new Dictionary<string, string>
        {
            { "ehsan", "qwerty" },
            { "wigo4it", "welkom01" }
        };
        private readonly string _key;

        public JwtManager(string key)
        {
            _key = key;
        }

        public string Authenticate(string userName, string password)
        {
            if (!users.Any(u => u.Key == userName && u.Value == password))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userName)
                }),
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
                //Issuer = "https://https://blijvenlerenapi.azurewebsites.net/",
                //Audience = "https://https://blijvenlerenapi.azurewebsites.net/"
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
