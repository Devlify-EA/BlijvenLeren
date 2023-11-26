using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;

namespace BL.DAL
{
    public abstract class CosmosDbRepository
    {
        protected readonly Container CosmosContainer;

        public CosmosDbRepository(IOptions<AzureCosmosDbOptions> azureCosmosDbOptions)
        {
            var cosmosClient = new CosmosClient(azureCosmosDbOptions.Value.EndpointUri, azureCosmosDbOptions.Value.PrimaryKey, new CosmosClientOptions() { ConnectionMode = ConnectionMode.Direct });
            CosmosContainer = cosmosClient.GetContainer(azureCosmosDbOptions.Value.DatabaseId, azureCosmosDbOptions.Value.ContainerName);
        }
    }
}
