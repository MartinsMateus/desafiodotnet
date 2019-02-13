using System.Collections.Generic;
using System.Security.Claims;

namespace Adolfo.AspNetIdentity
{
    public interface IUser
    {
        string Name { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
