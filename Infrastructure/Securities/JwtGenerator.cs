using Application.Helpers;
using Application.Interfaces;
using Domain.Configurations;
using Domain.Entities;
using Domain.Results.Auths;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Securities
{
    public class JwtGenerator : IJwtGenerator
    {
        private readonly string _KeySecurity;
        private readonly TokenManagement tokenSettings;

        public JwtGenerator(IConfiguration configuration,
            IOptions<TokenManagement> tokenSettings)
        {
            _KeySecurity = configuration["KeySecurity"];
            this.tokenSettings = tokenSettings.Value;
        }

        public async Task<AuthResult> CreateToken(UserMe auth)
        {
            var claims = new[] {
                new Claim(JWTClaimTypes.User, auth.NamerCort),
                new Claim(JWTClaimTypes.SexUser, auth.SexUser),
                new Claim(JWTClaimTypes.Profile, auth.Profile),
               /* new Claim(JWTClaimTypes.MigrationVenta, Convert.ToString (auth.Permit.MigrationVenta)),
                new Claim(JWTClaimTypes.MigrationNoteCredit,Convert.ToString( auth.Permit.MigrationNoteCredit)),
                new Claim(JWTClaimTypes.MigrationCancellation, Convert.ToString (auth.Permit.MigrationCancellation)),
                new Claim(JWTClaimTypes.MigrationAnul,Convert.ToString (auth.Permit.MigrationAnul)),
                new Claim(JWTClaimTypes.MigrationAdmin,Convert.ToString (auth.Permit.MigrationAdmin)),*/
                new Claim(JWTClaimTypes.FullName, auth.FullName),
                new Claim(JWTClaimTypes.LastName, auth.LastName),
                new Claim(JWTClaimTypes.CellMobil, auth.CellMobil),
                new Claim(JWTClaimTypes.TeleHouse, auth.TeleHouse),
                new Claim(JWTClaimTypes.Email, auth.Email),
                new Claim(JWTClaimTypes.Address, auth.Address),
                new Claim(JWTClaimTypes.Dni, auth.Dni),
            };

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.Secret));
            var encryptingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.EncryptionSecret));
            var now = DateTime.UtcNow;
            var expiresAt = DateTime.UtcNow.AddMinutes(tokenSettings.AccessExpiration);

            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            var encryptingCredentials = new EncryptingCredentials(encryptingKey, SecurityAlgorithms.Aes128KW, SecurityAlgorithms.Aes128CbcHmacSha256);

            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.CreateJwtSecurityToken(
                tokenSettings.Issuer,
                tokenSettings.Audience,
                new ClaimsIdentity(claims),
                now,
                expiresAt,
                now,
                signingCredentials: signingCredentials,
                encryptingCredentials: encryptingCredentials
            );

            var token = await Task.Run(() => handler.WriteToken(jwtSecurityToken));
            var expirationTimestamp = DateTimeHelper.GetUnixTimeMilliseconds(expiresAt);

            return new AuthResult(token, expirationTimestamp);
        }

        public static class JWTClaimTypes
        {
            public const string User = "https://suiza-dashboard-sap-fe/user";
            public const string MigrationVenta = "https://suiza-dashboard-sap-fe/Venta";
            public const string MigrationNoteCredit = "https://suiza-dashboard-sap-fe/NoteCredit";
            public const string MigrationCancellation = "https://suiza-dashboard-sap-fe/Cancellation";
            public const string MigrationAnul = "https://suiza-dashboard-sap-fe/Anu";

            public const string SexUser = "https://suiza-dashboard-sap-fe/SexUser";
            public const string Profile = "https://suiza-dashboard-sap-fe/Profile";
            public const string CodeProfile = "https://suiza-dashboard-sap-fe/CodeProfile";
            public const string DescriptionProfile = "https://suiza-dashboard-sap-fe/DescriptionProfile";
            public const string MigrationAdmin = "https://suiza-dashboard-sap-fe/MigrationAdmin";
            public const string FullName = "https://suiza-dashboard-sap-fe/NameMommy";
            public const string LastName = "https://suiza-dashboard-sap-fe/LastName";
            public const string CellMobil = "https://suiza-dashboard-sap-fe/CellMobil";
            public const string TeleHouse = "https://suiza-dashboard-sap-fe/TeleHouse";
            public const string Email = "https://suiza-dashboard-sap-fe/Email";
            public const string Address = "https://suiza-dashboard-sap-fe/Address";
            public const string Dni = "https://suiza-dashboard-sap-fe/Dni";

        }
    }
}
