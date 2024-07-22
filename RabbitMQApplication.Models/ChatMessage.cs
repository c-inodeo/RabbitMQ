using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQApplication.Models
{
    public class ChatMessage
    {
        [Key]
        public int Id { get; set; }
        public int User { get; set; }
        public string? ChatContent { get; set; }
        public DateTime? Created { get; set; } //to sort messages

    }
}
