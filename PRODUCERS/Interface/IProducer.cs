using System;
using System.Threading.Tasks;

namespace DOTNET_KAFKA.Interface
{
    public interface IProducer
    {
        void Gravar (string topico, string mensagem);
    }
}
