namespace AutoRecon.Infrastructure
{
    public class AzureVMInfo
    {
        public string ResourceGroupName { get; set; }
        public string VMName { get; set; }
        public string? Location { get; set; }
    }
}