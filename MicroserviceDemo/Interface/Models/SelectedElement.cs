namespace MicroserviceDemo.Models
{
    public class SelectedElement
    {
        public Guid Id { get; set; }
        public Element Element { get; set; }
        public int Quantity { get; set; }
        public SelectedElement Clone()
        {
            return new SelectedElement
            {
                Id = Id,
                Element = Element.Clone(),
                Quantity = Quantity
            };
        }
    }
}
