namespace API.Entities;



public record Items
{

    //Guid is  a "A GUID is a 128-bit integer"
    // "init" accessor  
    //Creating the propertoes of the items 
    public Guid Id { get; init; }
    public string Name { get; init; }

    public decimal Price { get; init; }

    public DateTimeOffset CreateDate { get; init; }



}