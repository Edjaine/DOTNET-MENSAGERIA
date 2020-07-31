using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOTNET_KAFKA.Interface;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;

namespace DOTNET_KAFKA.Infra.Mensageria
{
    public class RabbitProducer : IProducer
    {
        private readonly IRabbitConfiguration _rabbitConfiguration;

        public RabbitProducer(IRabbitConfiguration rabbitConfiguration)
        {
            _rabbitConfiguration = rabbitConfiguration;
        }
        public void Gravar(string topico, string mensagem)
        {
            var factory = new ConnectionFactory()
            {
                HostName = _rabbitConfiguration.Hostname,
                Port = _rabbitConfiguration.Port,
                UserName = _rabbitConfiguration.User,
                Password = _rabbitConfiguration.Password
            };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                //channel.ExchangeDeclare(exchange: "log", type: ExchangeType.Topic);

                // channel.QueueDeclare(queue: topico,
                //                      durable: false,
                //                      exclusive: false,
                //                      autoDelete: false,
                //                      arguments: null);
                
                string message =
                    $"{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} - " +
                    $"Conteúdo da Mensagem: {mensagem}";
                    
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: "log",
                                     routingKey: "",
                                     basicProperties: null,
                                     body: body.ToArray());
            }
        }       
    }
}
