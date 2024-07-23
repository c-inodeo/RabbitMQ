using RabbitMQ.Client;
using RabbitMQApplication.Models;
using RabbitMQApplication.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RabbitMQApplication.Services
{
    public class ProducerService : IProducerService
    {
        public async Task SendMessage<T>(ChatMessage message)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.ExchangeDeclare(
               exchange: "Chat Messages",
               type: ExchangeType.Fanout,
               durable: false,
               autoDelete: false,
               arguments: null
           );

            var json = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(
                 exchange: "",
                 routingKey: "Chat Messages",
                 basicProperties: null,
                 body: body
             );
            await Task.CompletedTask;
        }
    }
}
