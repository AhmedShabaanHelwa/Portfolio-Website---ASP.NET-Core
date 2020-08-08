//Only use what you need

namespace Core.Entities
{
    public class Address : EntityBase
    {
        public string Street { get; set; }
        public string City { get; set; }
        public int Number { get; set; }
    }
}
