using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace CONSUMERS
{
    class Program
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() {                 
                                                   HostName = "localhost",
                                                   Port = 5672,
                                                   UserName = "testes",
                                                   Password = "Testes2018!"
                                                   };
            using(var connection = factory.CreateConnection())
            using(var channel = connection.CreateModel())
            {
                //channel.ExchangeDeclare(exchange: "log", type: ExchangeType.Fanout);
    
                //var queueName = channel.QueueDeclare().QueueName;
                channel.QueueBind(queue: "minha_fila",
                                  exchange: "log",
                                  routingKey: "");
    
                Console.WriteLine(" [*] Waiting for logs.");
    
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] {0}", message);
                };
                channel.BasicConsume(queue: "minha_fila",
                                     autoAck: true,
                                     consumer: consumer);
    
                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }

        }
    }
}
