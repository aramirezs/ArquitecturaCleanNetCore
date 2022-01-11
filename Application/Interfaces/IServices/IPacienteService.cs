using Domain.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IServices
{
    public interface IPacienteService
    {
        Task<(ServiceStatus, string, RegistroPacienteEntity)> ConsultaPaciente(GetPacienteByDniRequest request);
        Task<PacienteNuevoResponse> RegistroNuevoPaciente(PacienteNuevoRequest request);
    }
}
