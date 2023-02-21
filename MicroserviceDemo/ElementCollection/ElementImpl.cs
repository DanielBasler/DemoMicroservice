using MicroserviceDemo.Models;

namespace MicroserviceDemo.ElementCollection
{
    public class ElementImpl : IElementCollection
    {
        private Element[] _elements = new[]
        {
            new Element{Id = new Guid("315D2E40-1646-41F5-86A4-A2203C6CD1B3"), Name = "Element 1" },
            new Element{Id = new Guid("FF2B532B-A92E-4DCF-A7FD-BD5B03E190A1"), Name = "Element 2" },
            new Element{Id = new Guid("2B5A6FF0-37A3-44ED-9E38-ED0F551B9038"), Name = "Element 3" },
            new Element{Id = new Guid("2F498F14-CB5A-4C46-AF27-2DCF8859E63E"), Name = "Element 4" },
            new Element{Id = new Guid("24F90E19-7593-4719-9D5F-F0C339ED2CD6"), Name = "Element 5" },
            new Element{Id = new Guid("24B5F3A8-25E8-4D06-83EE-4714C523E97F"), Name = "Element 6" }
        };

        public IEnumerable<Element> Get()
        {
            return _elements;
        }

        public Element Get(Guid elementId)
        {
            return _elements.FirstOrDefault(p => p.Id == elementId);
        }
    }
}
