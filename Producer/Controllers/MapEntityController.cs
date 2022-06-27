using Microsoft.AspNetCore.Mvc;
using Producer.Models;
using Producer.Services.Interfaces;

namespace Producer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MapEntityController : ControllerBase
    {
        private readonly IMessageProducer _messagePublisher;

        public MapEntityController( IMessageProducer messagePublisher)
        { 
            _messagePublisher = messagePublisher;
        }

        //end point POST
        [HttpPost]
        public bool Post([FromForm] string topic, [FromForm] MapEntityDto mapEntityDto)
        {
            _messagePublisher.SendMessage(topic, mapEntityDto);
            return true;
        }
    }
}