using Microsoft.AspNetCore.Mvc;

namespace MicroserviceDemo.WebClient.Controllers
{
    public class ElementController : Controller
    {
        private IElementCollection _elementCollection;
        private IElementsSelected _elementsSelected;

        public ElementController(IElementCollection elementCollection, IElementsSelected elementsSelected)
        {
            _elementCollection = elementCollection;
            _elementsSelected = elementsSelected;
        }

        public object GetElements()
        {
            var res = _elementCollection.Get();
            return res;
        }

        public object GetElementsSelected()
        {
            var res = _elementsSelected.Get();
            return res;
        }
    }
}
