using Domain.Entities;
using Domain.Results.Auths;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IJwtGenerator
    {
        Task<AuthResult> CreateToken(UserMe me);
    }
}
