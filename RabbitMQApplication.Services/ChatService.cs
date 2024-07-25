using RabbitMQApplication.Services.Interface;
using RabbitMQApplication.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace RabbitMQApplication.Services
{
    public class ChatService : IChatService
    {
        private readonly ApplicationDbContext _context;

        public ChatService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task <List<ChatMessage>> MessagesToList()
        {
            return await _context.ChatMessages.ToListAsync();
        }
    }
}
