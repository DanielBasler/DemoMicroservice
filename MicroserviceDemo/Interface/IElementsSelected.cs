using MicroserviceDemo.Models;
using Shed.CoreKit.WebApi;

namespace MicroserviceDemo
{
    public interface IElementsSelected
    {
        AbstractElements Get();
        [HttpPut, Route("addelement/{elementId}/{qty}")]
        AbstractElements AddElement(Guid elementId, int qty);
        AbstractElements DeleteElement(Guid elementId);
    }
}
