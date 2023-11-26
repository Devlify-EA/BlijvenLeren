using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using BL.DAL;
using BL.Domain.Models;
using BL.Domain.Enums;

namespace BL.UnitTests.Repository
{
    internal sealed class CosmosDbFakeRepository : IBlijvenLerenRepository
    {
        public async Task<Resource> CreateResourceAsync(Resource resource)
        {
            await Task.Yield();
            return resource;
        }

        public async Task<bool> DeleteResourceAsync(string id)
        {
            await Task.Yield();
            return true;
        }

        public async Task<IList<T>> GetDocumentsByTypeAsync<T>(DocumentType documentType) where T : IDocument
        {
            throw new NotImplementedException();

        }

        public async Task<Resource> GetResourceByIdAsync(string id)
        {
            await Task.Yield();
            return id switch
            {
                ConstantValues.FoundId => new Resource() { Id = id },
                ConstantValues.UpdatedId => new Resource() { Id = id },
                ConstantValues.NotFoundId => null,
                ConstantValues.ServerError500 => throw new Exception("500"),
                _ => null
            };
        }

        public async Task<Resource> UpdateResourceAsync(Resource resource)
        {
            var id = resource.Id;
            resource.Title = ConstantValues.UpdatedId;
            await Task.Yield();
            return id switch
            {
                ConstantValues.FoundId => resource,
                ConstantValues.UpdatedId => resource,
                ConstantValues.NotFoundId => null,
                ConstantValues.ServerError500 => throw new Exception("500"),
                _ => null
            };
        }
    }
}
