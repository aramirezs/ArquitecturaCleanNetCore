using System.Runtime.Serialization;

namespace Domain.Results
{
    [DataContract]
    public sealed class MessageResult
    {
        [DataMember(Name = "message")]
        public string Message { get; private set; }

        private MessageResult(string message)
        {
            Message = message;
        }

        public static MessageResult Of(string message)
        {
            var result = new MessageResult(message);

            return result;
        }
    }
}

