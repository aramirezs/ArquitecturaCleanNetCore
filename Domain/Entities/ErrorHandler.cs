using System;
using System.Net;
using System.Runtime.Serialization;

namespace Domain.Entities
{
    public class ErrorHandler : Exception
    {
        [IgnoreDataMember]
        public HttpStatusCode Code { get; }

        [DataMember(Name = "message")]
        public string Message { get; }

        public ErrorHandler(HttpStatusCode code, string message)
        {
            Code = code;
            Message = message;
        }

        public static ErrorHandler Of(HttpStatusCode code, string message)
        {
            var result = new ErrorHandler(code, message);

            return result;
        }
    }
}
