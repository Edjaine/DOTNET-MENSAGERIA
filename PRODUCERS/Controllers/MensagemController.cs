using Microsoft.AspNetCore.Mvc;
using KAFKA_DOTNET_CORE.Model;
using System;
using DOTNET_KAFKA.Interface;
using System.Threading.Tasks;

namespace KAFKA_DOTNET_CORE.Controllers{
    [ApiController]
    [Route("[controller]")]
    public class MensagemController : ControllerBase {
        private readonly IProducer _producer;
        public MensagemController(IProducer producer)   
        {
            _producer = producer;            
        }

        [HttpPost]
        public IActionResult Post([FromBody] string mensagem){            
            _producer.Gravar("minha_fila", mensagem);
            return Ok(new { Resultado = "Mensagem enviada com sucesso"}); 
        }
    }

}