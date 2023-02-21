using MicroserviceDemo.Models;

namespace MicroserviceDemo.ElementsSelection
{
    public class SelectedImpl : IElementsSelected
    {
        private static List<SelectedElement> _selectedElements= new List<SelectedElement>();
        private IElementCollection _elementCollection;

        public SelectedImpl(IElementCollection elementCollection)
        {
            _elementCollection = elementCollection;
        }

        public AbstractElements AddElement(Guid elementId, int qty)
        {
            var selectElement = _selectedElements.FirstOrDefault(i => i.Element.Id == elementId);
            if (selectElement != null)
            {
                selectElement.Quantity += qty;
            }
            else
            {
                var element = _elementCollection.Get(elementId);
                if (element != null)
                {
                    selectElement = new SelectedElement
                    {
                        Id = Guid.NewGuid(),
                        Element = element,
                        Quantity = qty
                    };

                    _selectedElements.Add(selectElement);
                }
            }

            return Get();
        }

        public AbstractElements DeleteElement(Guid elementId)
        {
            var selectElement = _selectedElements.FirstOrDefault(i=> i.Id == elementId);
            if(selectElement != null)
            {
                _selectedElements.Remove(selectElement);
            }

            return Get();
        }

        public AbstractElements Get()
        {
            return new AbstractElements
            {
                SelectedElements = _selectedElements
            };
        }
    }
}
