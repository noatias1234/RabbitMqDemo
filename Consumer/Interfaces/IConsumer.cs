using Consumer.Model;

namespace Consumer.Interfaces;

public interface IConsumer
{
    void RecieveMessage(String topic, MapEntityDto mapEntityDto);
}
