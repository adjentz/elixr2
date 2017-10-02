using System;

namespace Elixr2.Api.Services
{
    public class ServiceException : Exception
    {
        public ServiceException(string friendlyMessage, ServiceExceptionCode code)
        {
            this.FriendlyMessage = friendlyMessage;
            this.Code = code;
        }
        public string FriendlyMessage { get; }
        public ServiceExceptionCode Code { get; }
        public enum ServiceExceptionCode
        {
            Permission = 0,
            Validation = 10
        }
    }
}