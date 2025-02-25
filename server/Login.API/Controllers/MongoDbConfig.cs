using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

public class MongoDBConfig
{
    public string ConnectionString { get; set; }
    public string CollectionName { get; set; }
    public string DatabaseName { get; set; }
}

public class MongoDBService
{
    private readonly IMongoCollection<BsonDocument> _collection;

    public MongoDBService(IOptions<MongoDBConfig> configOptions)
    {
        var config = configOptions.Value;
        var client = new MongoClient(config.ConnectionString);
        var database = client.GetDatabase(config.DatabaseName);
        _collection = database.GetCollection<BsonDocument>(config.CollectionName);
    }

    public async Task CreateAsync(BsonDocument documento)
    {
        await _collection.InsertOneAsync(documento);
    }

    public async Task<BsonDocument> FindAsync(string email)
    {
        var filter = Builders<BsonDocument>.Filter.Eq("email", email);
        return await _collection.Find(filter).FirstOrDefaultAsync();
    }
}