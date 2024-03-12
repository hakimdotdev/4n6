using AutoRecon.Domain.Common;

namespace AutoRecon.Domain.Entities.Recon
{
    public class Module() : BaseEntity
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public virtual List<string> Tags { get; set; } = ["default"];
        public int Priority { get; set; } = 1;
        public Dictionary<string, object> Options { get; } = [];
    }
}