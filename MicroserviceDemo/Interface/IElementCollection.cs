using MicroserviceDemo.Models;
using Shed.CoreKit.WebApi;

namespace MicroserviceDemo
{
    public interface IElementCollection
    {
        IEnumerable<Element> Get();

        [Route("get/{elementId}")]
        public Element Get(Guid elementId);
    }
}
