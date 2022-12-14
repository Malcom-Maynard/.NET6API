using API.Entities;
using API.Repositories;
using MongoDB.Driver;
using API.Settings;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//making the DB see Guid and dates as Strings 
BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));

BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));
//Registering service for Dependency injection (Interface,Implemented class)

builder.Services.AddSingleton<IMongoClient>(ServiceProvider =>
{
    var settings = builder.Configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();
    return new MongoClient(settings.ConnectionString);

});
builder.Services.AddSingleton<IinMemitemsRespository, MongoDbItemsRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
