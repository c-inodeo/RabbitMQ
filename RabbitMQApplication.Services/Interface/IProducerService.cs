﻿using RabbitMQApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQApplication.Services.Interface
{
    public interface IProducerService
    {
        Task SendMessage<T> (ChatMessage message);
    }
}
