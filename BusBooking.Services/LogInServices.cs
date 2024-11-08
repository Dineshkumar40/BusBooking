using BusBooking.Models.Models;
using BusBooking.Repositories;
using BusBooking.Repositories.Interfaces;
using BusBooking.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking.Services
{
    public  class LogInServices(IUsersRepository usersRepository) : ILogInServices
    {
        public async Task<ServiceResponse> ToAuth(ToAuth auth)
        {
            return await usersRepository.ToAuth(auth);
        }
        public async Task<ServiceResponseData<CheckAuth>> CheckAuth(ToAuth toAuth)
        {
            var userInfo = await usersRepository.GetAuth(toAuth);

            if (userInfo.Status == ServiceStatusType.Success)
            {
                var claims = new List<Claim>()
                {
                    //new Claim(JwtRegisteredClaimNames.Iat,DateTime.Now.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                    new Claim("UserId",userInfo.Data.UserId),
                    new Claim("RoleType",userInfo.Data.RoleType),

                };
                userInfo.Data.JwtToken = GetTokenString(claims);

            }

            return userInfo;
        }
        private string GetTokenString(List<Claim> claims)
        {
            string result = null;
            try
            {
                string JwtRsaPrivateKey = "MIIEowIBAAKCAQEA8m5lWBlWxwJMCt168RBPnwAe8oy702fANVwFSKOnGEMI+os5kbeQX8ulUY82euj4d2P2ngmeu5PK2NF7J5YWdXoDjXrbegQn3F0SV7K66HBFuyNDQwGIi8B2PWR3qIAVVZBuy0VrMSW5wxJpIt7WBW1CUleO/QgZ9vXbCRqz8U6407lORYuV1ca/BPjFd/iKTnO6mTtGonBBljEeKcBcSQyTWaJJny8xySapkxQt6UWdCHLeBZ+H2HyC+pUGbGLJaLz0/zdu+3z40puK5SfQtU1KVOehEzb82lTfISTBFmHQzx50nk0Fnt6n3kOqoHRqz9k0QfKfXCe4Pv8RttSIxQIDAQABAoIBAHbtfT3owE9EazVxTVxw2f5wOr5WF9YvsXT7vYPS9KfMSt1N62H2oRa9ek42aU2GeE1pdpQ0t+/hIsOWkEntMPtUbeW7/WswGrXZ2qO3BEX+vdZ+CAMY/3k/Y0HexWyd2Nluz0tctKcZkLWHlJgMpQVogf6PAZBTpxklptwig1++gCgATozpf8bWYsrsqSRtXlfdw+B5A10WYOLyjr/U8UCub6+EQHrhq1QOfyWLPHeDraxe8kOSWRBPCtMDb6Ok6pvmg6uKdejyOOpXG/aw+F82+8UjaA3LfSg6AVeQyxvXRLmlrlIT/drYlcAuy3PIUsEp3hNH6p9CfSxFppVqiAkCgYEA9DVoKr9Xw6YUfwHG9DwCKHQqQPxtZ47gM2W9LEOM56OegFRentKFFVd/BibVgfSHXymk7WZbVjHx1Lzw+Epox5kXdT4s/0e+/Y4PuboNTIXUX3n1ogaufEqc2mGvNaPItqR816q56woBH5dukKszgIq8ADyITVJyrZeuBqqFTX8CgYEA/iME6mf93EfCGUWHLTnvk3NH7q2I3j9cBwtNsdQUlWxvhUT3Wln8H/9cKJcc4MZBgUAGFnDSvJgQkmszgWx0fKcbhnVMe67FuOsTzRvnQpZjF4JLoW4gnRHuYA0kVgNXLsRCifx9hohkbmRSY5edQw7R0ZPR4j+fH/i4bHiLk7sCgYEAyjefNiaTihLwTesuz/cQ4mauxnlALsyEoorQhuK4vuchzKoQX/t68B0vtexaR+4wWoClbV+gqlNZKQv7jd4vvXfrkM4XfJvwbw0/wE9ry73WCel3mN9nhMxT7hGNgCFLhtHV/tAEe7ghDgPbLjhVwU8gNiHpy/1FsLE1DZgOIgkCgYBPR+N3sPtsJeKyeZNDE6jeqf8NwYtKMh/mfqs9R7koKEzeGXbE8/+Ih+RbMVEr+g1jYfLEO2wys4mv88t8m7X3UTZwCtXSW+KI3qUtvn+1sS62nco0USPRfE+OHWtxfddL2qQbYe5S8ufJ3HgrY5gG3G+uXtwCJfDhS3lVNYHtkwKBgE/Lp+VoCr6xnadORVWpUbNX3tzMRZf0Ie3v0jbReM3GYCkAssbvpJ1hjdNbgwMEjS0FjSi0vBMERBW+/a/zEHc6dUP5dd3hfr92zbbVDNv0cawrW7jfMRSfCyYgcK3/YuOZ198onHUerIPQt9tl/UZRh0kqAnM6wFg73Nj8NT5G";
                RSA rSA = RsaKeyAsPerContent(JwtRsaPrivateKey);
                RsaSecurityKey securityKey = new RsaSecurityKey(rSA);
                SigningCredentials signIn = new SigningCredentials(securityKey, SecurityAlgorithms.RsaSha512);
                JwtSecurityToken jwtToken = new JwtSecurityToken(
                    "hexaware",
                    "hexawarwusers",
                    claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: signIn);
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                result = tokenHandler.WriteToken(jwtToken);
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        private RSA RsaKeyAsPerContent(string privateKey)
        {
            RSA rSA = RSA.Create();
            var privateKeyBytes = Convert.FromBase64String(privateKey);
            rSA.ImportRSAPrivateKey(privateKeyBytes, out int _);
            return rSA;
        }

    }
}
