using Newtonsoft.Json;
using Producer.Models;
using Producer.Services.Interfaces;
using RabbitMQ.Client;
using System.Text;

namespace Producer.Services;

public class RabbitMQProducer : IMessageProducer
{
    public void SendMessage(string topic, MapEntityDto mapEntityDto)
    {
        var factory = new ConnectionFactory { HostName = "localhost" };
        var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare(queue: topic, durable: false, exclusive: false, autoDelete: false, arguments: null);

        var json = JsonConvert.SerializeObject(mapEntityDto, Formatting.Indented);
        var body = Encoding.UTF8.GetBytes(json);

        channel.BasicPublish(
            exchange: "",
            routingKey: topic,
            body: body);
    }
}