using Consumer.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Consumer;
public class Consumer : IConsumer
{
    var factory = new ConnectionFactory() { HostName = "localhost" };
    var connection = factory.CreateConnection();
    var channel = connection.CreateModel();

    channel.ExchangeDeclare(exchange: "mapEntity", type: ExchangeType.Topic);

        var queueName = channel.QueueDeclare().QueueName;

    // Tell the exchange to send messages to our queue
    channel.QueueBind(queue: queueName,
                          exchange: "mapEntity",
                          routingKey: "");

        Console.WriteLine(" [*] Waiting for mapEntity.");

        var consumer = new EventingBasicConsumer(channel);
    consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine(" [x] {0}", message);
        };
channel.BasicConsume(queue: queueName,
                             autoAck: true,
                             consumer: consumer);

        Console.WriteLine(" Press [enter] to exit.");
        Console.ReadLine();
  
    }

