using System;
using DOTNET_KAFKA.Interface;
using Microsoft.Extensions.Configuration;

namespace DOTNET_KAFKA.Infra.Mensageria
{
    public class RabbitConfiguration: IRabbitConfiguration
    {
        public RabbitConfiguration(IConfiguration configuration)
        {
            this._hostName = configuration.GetSection("rabbit-server").GetSection("hostname").Value;
            this._port = int.Parse(configuration.GetSection("rabbit-server").GetSection("port").Value);
            this._user = configuration.GetSection("rabbit-server").GetSection("user").Value;
            this._password = configuration.GetSection("rabbit-server").GetSection("password").Value;
        }

        private string _hostName;
        string IRabbitConfiguration.Hostname { get { return _hostName; }  set {} }
        private int _port;
        int IRabbitConfiguration.Port { get { return _port; }  set {}  }
        private string _user;
        string IRabbitConfiguration.User { get  { return _user; } set {} }        
        private string _password;
        string IRabbitConfiguration.Password { get {return _password; }  set {} }
    }
}
