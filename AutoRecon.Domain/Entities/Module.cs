
namespace AutoRecon.Domain.Common
{
    public abstract class Module()
    {
        public required string Name { get; set; }
        public required string Slug { get; set; }
        public required string Description { get; set; }
        public virtual List<string> Tags { get; set; } = ["default"];
        public int Priority { get; set; } = 1;
        public Dictionary<string, object> Options { get; } = [];
    }

}
