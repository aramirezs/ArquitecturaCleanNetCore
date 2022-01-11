﻿using System.Runtime.Serialization;

namespace Domain.Payloads.Auths
{
    [DataContract]
    public class AuthPayload
    {
        [DataMember(Name = "username")]
        public string Username { get; set; }

        [DataMember(Name = "password")]
        public string Password { get; set; }
    }
}