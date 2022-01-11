using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Payloads.Patient
{
    public class PatientPayload
    {
       [DataMember(Name = "numeroDocumento")]
        public string NumeroDocumento { get; set; }
       [DataMember(Name = "tipoDocumento")]
        public string TipoDocumento { get; set; }
        [DataMember(Name = "nombre")]
        public string Nombre { get; set; }
        [DataMember(Name = "apellidoPaterno")]
        public string ApellidoPat { get; set; }
        [DataMember(Name = "apellidoMaterno")]
        public string ApellidoMat { get; set; }
        [DataMember(Name = "anoPaciente")]
        public string Anopac { get; set; }
        [DataMember(Name = "numeroPaciente")]
        public string Numpac { get; set; }
        [DataMember(Name = "sexo")]
        public string Sexo { get; set; }
        [DataMember(Name = "fechaNacimiento")]
        public string FechaNac { get; set; }
        [DataMember(Name = "telefonoCelular")]
        public string TelefonoCel { get; set; }
        [DataMember(Name = "direccionPaciente")]
        public string Dirpac { get; set; }
        [DataMember(Name = "email")]
        public string Email { get; set; }
        [DataMember(Name = "usuario")]
        public string UsuarioWeb { get; set; }
        [DataMember(Name = "password")]
        public string PasWeb { get; set; }
        [DataMember(Name = "flagCorreo")]
        public int FlagCorreo { get; set; }
        [DataMember(Name = "flagWhatsapp")]
        public int FlagWhatsapp { get; set; }
        [DataMember(Name = "codigoValidacion")]
        public string CodigoValidacion { get; set; }

     
    }
}
