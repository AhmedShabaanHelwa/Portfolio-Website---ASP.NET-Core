//Only use what you need

namespace Core.Entities
{
    //Project or Portfolio Item
    public class PortfolioItem: EntityBase
    {
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
