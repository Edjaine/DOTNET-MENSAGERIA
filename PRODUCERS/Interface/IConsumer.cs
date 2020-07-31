using System;
using System.Threading.Tasks;
using Confluent.Kafka;

namespace DOTNET_KAFKA.Interface
{
    public interface IConsumer
    {
        string Consulta (string topico);  
    }
}
