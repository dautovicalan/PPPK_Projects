using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CosmosDbOsoba.Dao
{
    public class CosmosDbServiceProvider
    {
        private const string DatabaseName = "People";
        private const string ContainerName = "OsobaManager";
        private const string Account = "https://adautovic.documents.azure.com:443/";
        private const string Key = "OphvRvWDnHuPiOGhOcq6rQUwlfzkPIxgw7fEDF2ehgkOZ45LizpWjHTIzYKycjZzzrPha2f9neubACDbN0R5Lg==";

        private static ICosmosDbService cosmosDbService;

        public static ICosmosDbService CosmosDbService { get => cosmosDbService; }

        public static async Task Init()
        {
            CosmosClient cosmosClient = new CosmosClient(Account, Key);
            cosmosDbService = new CosmosDbService(cosmosClient, DatabaseName, ContainerName);
            DatabaseResponse databaseResponse
                = await cosmosClient.CreateDatabaseIfNotExistsAsync(DatabaseName);
            await databaseResponse.Database.CreateContainerIfNotExistsAsync(ContainerName, "/id");
        }
    }
}