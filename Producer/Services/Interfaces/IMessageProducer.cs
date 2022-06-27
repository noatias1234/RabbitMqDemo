using Producer.Models;

namespace Producer.Services.Interfaces;

public interface IMessageProducer
{
    void SendMessage(string topic, MapEntityDto mapEntityDto);
}