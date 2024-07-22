using Microsoft.EntityFrameworkCore;
using RabbitMQApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQApplication.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) :base(option) 
        { 
        
        
        }   
       
    }
}
