namespace API.Repositories;
using System.Collections.Generic;
using API.Entities;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson;


public class MongoDbItemsRepository : IinMemitemsRespository
{

    private const string DbName = "API-DB";
    private const string collectionName = "Items";
    private readonly IMongoCollection<Items> itemCollection;

    private readonly FilterDefinitionBuilder<Items> filterbuildeer = Builders<Items>.Filter;

    //Creating MongoDB client 
    public MongoDbItemsRepository(IMongoClient mongoClient)
    {

        //Driver decects if these have been created or not 
        IMongoDatabase database = mongoClient.GetDatabase(DbName);
        itemCollection = database.GetCollection<Items>(collectionName);

    }

    //Returns all items in the list
    public IEnumerable<Items> GetItems()
    {

        return itemCollection.Find(new BsonDocument()).ToList();

    }

    //Returns a items based on given id 
    public Items getItem(Guid id)
    {

        var filter = filterbuildeer.Eq(Items => Items.Id, id);
        return itemCollection.Find(filter).SingleOrDefault();
    }

    //Adding new item in the Database
    public void CreateItem(Items item)
    {
        itemCollection.InsertOne(item);

    }
    //Updating a item from the database
    public void UpdateItem(Items item)
    {

        var filter = filterbuildeer.Eq(ExistingItem => ExistingItem.Id, item.Id);
        itemCollection.ReplaceOne(filter, item);
    }
    //Deleteing item from a database
    public void DeleteItem(Guid id)
    {
        var filter = filterbuildeer.Eq(ExistingItem => ExistingItem.Id, id);
        itemCollection.DeleteOne(filter);


    }


}