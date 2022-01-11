using Domain.Results.Users;
using System.Security.Claims;
using static Infrastructure.Securities.JwtGenerator;

namespace SuizaOnlineBackend.Authentications
{
    public static class ClaimsPrincipalExtension
    {
        public static UserMeResult GetUser(this ClaimsPrincipal principal)
        {
            var User = principal.FindFirstValue(JWTClaimTypes.User);

            var SexUser = principal.FindFirstValue(JWTClaimTypes.SexUser);
            var Profile = principal.FindFirstValue(JWTClaimTypes.Profile);
            var MigrationVenta = principal.FindFirstValue(JWTClaimTypes.MigrationVenta);
            var MigrationNoteCredit = principal.FindFirstValue(JWTClaimTypes.MigrationNoteCredit);
            var MigrationCancellation = principal.FindFirstValue(JWTClaimTypes.MigrationCancellation);
            var MigrationAnul = principal.FindFirstValue(JWTClaimTypes.MigrationAnul);
            var MigrationAdmin = principal.FindFirstValue(JWTClaimTypes.MigrationAdmin);

            var FullName = principal.FindFirstValue(JWTClaimTypes.FullName);
            var LastName = principal.FindFirstValue(JWTClaimTypes.LastName);
            var CellMobil = principal.FindFirstValue(JWTClaimTypes.CellMobil);
            var TeleHouse = principal.FindFirstValue(JWTClaimTypes.TeleHouse);
            var Email = principal.FindFirstValue(JWTClaimTypes.Email);
            var Address = principal.FindFirstValue(JWTClaimTypes.Address);
            var Dni = principal.FindFirstValue(JWTClaimTypes.Dni);



            return new UserMeResult(User, SexUser, Profile, MigrationAdmin,
                FullName, LastName, CellMobil, TeleHouse, Email, Address, Dni);


        }
    }
}