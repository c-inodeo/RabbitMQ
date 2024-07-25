using RabbitMQApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQApplication.Services.Interface
{
    public interface IChatService
    {
        Task <List<ChatMessage>> MessagesToList();
    }
}
