using System;
using System.Text;
using DOTNET_KAFKA.Interface;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace DOTNET_KAFKA.Infra.Mensageria
{
    public class RabbitConsumer : IConsumer
    {
        private readonly IRabbitConfiguration _rabbitConfiguration;

        public RabbitConsumer(IRabbitConfiguration rabbitConfiguration)
        {
            _rabbitConfiguration = rabbitConfiguration;
        }
        public string Consulta(string topico = "")
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
                channel.QueueDeclare(queue: topico,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += Consumer_Received;
                channel.BasicConsume(queue: topico,
                     autoAck: true,
                     consumer: consumer);
            }
            return "Consultada => ";
        }
        private static void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var message = Encoding.UTF8.GetString(e.Body.Span);
            Console.WriteLine(Environment.NewLine +
                "[Nova mensagem recebida] " + message);
        }

    }
}
