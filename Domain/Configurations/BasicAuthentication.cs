using System.Runtime.Serialization;

namespace Domain.Configurations
{
        [DataContract]
        public sealed class BasicAuthentication
        {
            [DataMember(Name = "user")]
            public string User { get; set; }

            [DataMember(Name = "password")]
            public string Password { get; set; }
        }    
}
