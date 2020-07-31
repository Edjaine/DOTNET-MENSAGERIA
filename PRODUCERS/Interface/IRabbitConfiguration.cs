using System;

namespace DOTNET_KAFKA.Interface
{
    public interface IRabbitConfiguration
    {
        public string Hostname { get; protected set; }
        public int Port { get; protected set; }
        public string User { get; protected set; }
        public string Password { get; protected set; }
    }
}
