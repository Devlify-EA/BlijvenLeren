namespace BL.DAL
{
    public class AzureCosmosDbOptions
    {
        public string EndpointUri { get; set; }
        public string PrimaryKey { get; set; }
        public string DatabaseId { get; set; }
        public string ContainerName { get; set; }
    }
}
