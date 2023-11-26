using BL.Domain.Enums;
using BL.Domain.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Azure.Cosmos;

namespace BL.DAL
{
    public class BlijvenLerenCosmosDbRepository : CosmosDbRepository, IBlijvenLerenRepository
    {
        private readonly ILogger<BlijvenLerenCosmosDbRepository> _logger;
        public BlijvenLerenCosmosDbRepository(IOptions<AzureCosmosDbOptions> azureCosmosDbOptions, ILogger<BlijvenLerenCosmosDbRepository> logger) : base(azureCosmosDbOptions)
        {
            _logger = logger;
        }

        public async Task<Resource> CreateResourceAsync(Resource resource)
        {
            try
            {
                return await CosmosContainer.CreateItemAsync(resource, new PartitionKey(resource.Id));
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                throw;
            }
        }

        public async Task<Resource> UpdateResourceAsync(Resource resource)
        {
            try
            {
                return await CosmosContainer.ReplaceItemAsync<Resource>(resource, resource.Id, new PartitionKey(resource.Id));
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                throw;
            }
        }

        public async Task<bool> DeleteResourceAsync(string id)
        {
            try
            {
                await CosmosContainer.DeleteItemAsync<Resource>(id, new PartitionKey(id));
                return true;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                throw;
            }
        }

        public async Task<IList<T>> GetDocumentsByTypeAsync<T>(DocumentType documentType) where T : IDocument
        {
            try
            {
                var query = "SELECT * FROM c WHERE c.documentType = @documentType";
                QueryDefinition queryDefinition = new QueryDefinition(query).WithParameter("@documentType", documentType);

                var documentsList = new List<T>();
                using (FeedIterator<T> feedIterator = CosmosContainer.GetItemQueryIterator<T>(queryDefinition))
                {
                    while (feedIterator.HasMoreResults)
                    {
                        foreach (var item in await feedIterator.ReadNextAsync())
                        {
                            documentsList.Add(item);
                        }
                    }
                }

                return documentsList;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                throw;
            }
        }

        public async Task<Resource> GetResourceByIdAsync(string id)
        {
            try
            {
                var result = await CosmosContainer.ReadItemAsync<Resource>(id, new PartitionKey(id));
                return result;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                throw;
            }
        }        
    }
}
