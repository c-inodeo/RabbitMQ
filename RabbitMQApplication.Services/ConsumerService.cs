using RabbitMQApplication.Services.Interface;
using RabbitMQApplication.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text.Json;
using RabbitMQApplication.Models;
using Microsoft.Extensions.DependencyInjection;

namespace RabbitMQApplication.Services
{
    public class ConsumerService : IConsumerService
    {
        private readonly IServiceProvider _service;

        public ConsumerService(IServiceProvider service)
        {
          _service = service;
        }
        public async Task Start()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            var conn = factory.CreateConnection();
            var channel = conn.CreateModel();

            channel.QueueDeclare(
                queue: "Chat Messages",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var chatMessage = JsonSerializer.Deserialize<ChatMessage>(message);

                if (chatMessage != null)
                {
                    using (var scope = _service.CreateAsyncScope())
                    {
                        var _context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                        _context.ChatMessages.Add(chatMessage);
                        await _context.SaveChangesAsync();
                    }
         
                }

                Console.WriteLine($"Sample message {chatMessage}");
            };

            channel.BasicConsume(
                queue: "Chat Messages",
                autoAck: true,
                consumer: consumer
            );
            await Task.CompletedTask;
        }
    }
}
