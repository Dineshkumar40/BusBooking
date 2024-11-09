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
                string JwtRsaPrivateKey = "MIIEpAIBAAKCAQEA5nSzCdDYzVQULW9uRmLB5yNqgBk4xqfo4tMKE/a2Cbb2O1DWOfsHeWyoZLS+9LtwC85ZT7hRgJehgFZbhW6BK4w5SVu+PnEbxbZI0tNfT/WfxV9DanS2NoImJadc5H6fOloYtxQLKYaI+AiXDQXeC9Kg3JYBc/J1Z4YIouARi+psWmWkbsbFKF+v/K0Kb6ikDUtIVc8+JF44CRIdEZwNgKkZUrbp/tsF6sU+QivxaLVp+9cZYAb14evg7qT2eZpNOHr2tvxxqA/W1pudn+3xcrJND4NiFwVYATN7im9RX7pCIooGplUOIWGiA5OfoQX5OKamRVTF0bU+puxZr9b+YQIDAQABAoIBAENNA1gzgIz+J+JY72howN3CbwC33OfO82kCXqgT3Xea0e/inJ1UHQut2sOGMVoBPyiDe3uXhV27anOzRIkEC37vNW+h9j4ABC9KG5xOFECip6UZO/Pj366tdXx7kto7zD5bP2p/1P6shmWBBLPN6dmkCkxBFm2I+hZggzclnpowLsG+vVJMgy661lLO2KT8NFx4VAPJI9eZnYfMigWFhmgcSXlaRW2+Xb8dL+namaoryGkxFKXezn9p/K4LGWeDXeGuMM5Osy3zLdKnAg4Le68zGNvB8b+KlyuDFH5YuZBAhmVwxGuUaqNA0IHRBPmgcyorYtHCuzPHLuJa0xLNdk0CgYEA+syabzY3yE9TWvZVAVHK1qWs+O9iOBE0cGZ3EjtrocToS50FpcLEgC69KJCT0GZus15UGmAhahmzV4XHF24f42pVsSIk54oGZZyUkLqY3Jy13SUZ7EFofem39S7Ti9YfRW2GwX5bG4sGmeL6Ux2uWU+FPT2zCgdPTInvp4RCjI8CgYEA6zwZ1+/4WyTqZZ2VBfnA8jFRElaBrlU4Zdox1JjM1rfZ+4ABWb4rsJWQRu36sEDzCiynO71pp3eVuZNZ7RTN34nmsXNos200IKqS87w1Nd1z5Vt+bUR0I8ceAD7+ojLqXS/5foiotpnk5k4Hi5W3CYgDvio9tahdbgvljNEIHg8CgYAdzqVoJEx67RqeC/rMXlk6K5SkPWcx/LF7zmHGc/N11X46Rl4+dih+h4+Ju60lrpbnkIV0YQp3nrhW5Zpk6Xy2vZOTqtgyAJCEERkDHno+dg2TS+6JyrhNhrKLXFZeH0O2L689XfQcEOjm7zgLGtL24GGYhrW5sma1VQt7oFd8dwKBgQDkCcNT3kH4uXSxRW4t+Mve/YgGKu5UPjEKK9earPYGQPyEHrcwdHaOHK9c017udkglWNxVwW0m93qiCAJpHn3lch29cI/TQM4DzNfgiFdc/G1ZrrSE4JNmC6U9v9PBEXK5G8TVsU08lzubN5GA84YZK03Vj8V60Nih0c6aEBm6aQKBgQDMZctPJwCCKUF8a9OpCxcIAD0wlm/27dk90EM+Ix4dV2F94PwpuU61Wb5tgmTBHphzB3MaTqLa+hRWHAP187nUkpIPQbbxouqjUGfCtAlqPkv4/wbFUCilEESdiyu3Nc69jASBqEpG5yW1MS1xZM60NHlxEz5sJfZQVFXdfsbngw==";
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
