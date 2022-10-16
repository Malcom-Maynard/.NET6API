namespace API;
using API.Dtos;
using API.Entities;



//Extending a definitions  of a type by adding a new method to it


public static class Extensions
{

    public static ItemDto AsDto(this Items item)
    {

        return new ItemDto
        {

            Id = item.Id,
            Name = item.Name,
            Price = item.Price,
            CreateDate = item.CreateDate





        };
    }

}