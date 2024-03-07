namespace AutoRecon.NET
{
    public class Plugin()
    {
        public required string Name { get; set; }
        public required string Slug { get; set; }
        public required string Description { get; set; }
        public List<string> Tags { get; set; } = ["default"];
        public int Priority { get; set; } = 1;
        public Dictionary<string, object> Options { get; } = [];
        public required Target Targets { get; set; }
    }
}
