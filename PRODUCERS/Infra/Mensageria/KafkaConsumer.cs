using System;
using System.Threading.Tasks;
using Confluent.Kafka;
using DOTNET_KAFKA.Interface;
using Microsoft.Extensions.Configuration;

namespace DOTNET_KAFKA.Infra.Mensageria
{
    public class KafkaConsumer : IConsumer
    {
        private readonly string _servidor;

        public KafkaConsumer(IConfiguration configuration)
        {            
            _servidor = configuration.GetSection("kafka-server").Value;
        }
        public string Consulta(string topico)
        {
            
            var conf = new ConsumerConfig {                
                GroupId = "consumidor-0001",
                BootstrapServers = _servidor,
                AutoOffsetReset = AutoOffsetReset.Earliest
                                
            };

            using(var consumer = new ConsumerBuilder<string, string>(conf).Build())
            {
                consumer.Subscribe(topico);                                       
                var result =  consumer.Consume();
                consumer.Commit(result);
                return result.Message.Value;

            }
        }
    }
}
