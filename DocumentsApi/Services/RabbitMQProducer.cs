using DocumentsApi.Services.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace DocumentsApi.Services
{
    public class RabbitMQProducer : IMessageProducer
    {
        public void SendMessage<T>(T message)
        {
            var factory = new ConnectionFactory
            {
                //rest of the values are default
                HostName = "localhost"
            };

            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare("documents", exclusive: false);

            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: "", routingKey: "documents", body: body);
        }
    }
}
