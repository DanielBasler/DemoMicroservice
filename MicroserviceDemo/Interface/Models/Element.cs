namespace MicroserviceDemo.Models
{
    public class Element
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Element Clone()
        {
            return new Element
            {
                Id = Id,
                Name = Name
            };
        }
    }
}
