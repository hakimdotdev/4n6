namespace AutoRecon.NET
{
    public class Target
    {
        public TargetType Type { get; set; }
        public List<string> Values { get; set; }

        public Target(TargetType type, string value)
        {
            Type = type;
            Values = [value];
        }

        public Target(TargetType type, List<string> values)
        {
            Type = type;
            Values = values;
        }
    }
}
