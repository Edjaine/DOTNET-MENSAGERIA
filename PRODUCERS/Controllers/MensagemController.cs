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
        private readonly IConsumer _consumer;

        public MensagemController(IProducer producer,
                                  IConsumer consumer)   
        {
            _producer = producer;
            _consumer = consumer;
        }

        [HttpPost]
        public IActionResult Post([FromBody] string mensagem){            
            _producer.Gravar("minha_fila", mensagem);
            return Ok(new { Resultado = "Mensagem enviada com sucesso"}); 
        }
        [HttpGet]
        public IActionResult Get(){
            var result = _consumer.Consulta("minha_fila");
            return Ok(result);
        }
    }

}