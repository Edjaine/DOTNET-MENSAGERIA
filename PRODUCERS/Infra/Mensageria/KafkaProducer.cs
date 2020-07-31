using System;
using System.Threading.Tasks;
using Confluent.Kafka;
using DOTNET_KAFKA.Interface;
using Microsoft.Extensions.Configuration;

namespace DOTNET_KAFKA.Infra.Mensageria
{
    public class KafkaProducer : IProducer
    {
        private readonly string _servidor;

        public KafkaProducer(IConfiguration configuration)
        {            
            _servidor = configuration.GetSection("kafka-server").Value;
        }
        public async void Gravar(string topico, string mensagem)
        {
            var config = new ProducerConfig { BootstrapServers = _servidor };

            using ( var producer = new ProducerBuilder<string, string>(config).Build())
            {
                try
                {
                    var chave = Guid.NewGuid();
                    var sendResult = await producer
                                        .ProduceAsync(topico, new Message<string, string> 
                                            { 
                                                Key = chave.ToString(), 
                                                Value = mensagem 
                                            });
                                               

                }
                catch (Exception) 
                {
                    throw;
                }
            }
        }
    }
}
