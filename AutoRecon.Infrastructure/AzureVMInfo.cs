namespace AutoRecon.Infrastructure
{
    public class AzureVMInfo
    {
        public required string ResourceGroupName { get; set; }
        public required string VMName { get; set; }
        public string? Location { get; set; }
    }

}