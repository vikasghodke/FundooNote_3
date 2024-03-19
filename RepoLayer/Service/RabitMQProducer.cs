using Newtonsoft.Json;
using RabbitMQ.Client;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Service
{
    public class RabitMQProducer : IRabitMQProducer
    {
        public void SendProductMessage<T>(T message)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            // Declare the queue if it doesn't exist
            channel.QueueDeclare(queue: "NOte", durable: false, exclusive: false, autoDelete: false, arguments: null);

            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);

            // Publish the message to the queue
            channel.BasicPublish(exchange: "", routingKey: "Note", basicProperties: null, body: body);
        }
    }
}

