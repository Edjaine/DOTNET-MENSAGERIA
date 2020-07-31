using System;
using Newtonsoft.Json;

namespace KAFKA_DOTNET_CORE.Model{
    public class Pedido {
        public Pedido()
        {
            Id = System.Guid.NewGuid().ToString();
        }
        private string Id { get; set; }
        public DateTime DataPedido { get; set; }
        public string Comprador { get; set; }
        public string ToJson(){

            var serializer = JsonConvert.SerializeObject(this);
            return serializer;
        }
    }

}