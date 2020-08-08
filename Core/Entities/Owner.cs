//Only use what you need

namespace Core.Entities
{
    //Owner class
    public class Owner : EntityBase
    {
        //The Owner name
        public string FullName { get; set; }
        //Profile: Job
        public string Profile { get; set; }
        //Avatar
        public string Avatar { get; set; }
        public Address Address { get; set; }
    }
}
