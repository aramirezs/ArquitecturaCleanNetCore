using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    class PatientService
    {
        private readonly IAuthenticationRepository authenticationRepository;

        private readonly IJwtGenerator jwtGenerator;
    }
}
