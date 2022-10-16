namespace API.Repositories;

using System.Collections.Generic;
using API.Entities;



public class inMemitemsRespository : IinMemitemsRespository
{

    //Defining the storage of items
    private readonly List<Items> items = new()
    {

        //Creating the deafult/ starting items
        new Items{ Id=Guid.NewGuid(),Name="Potion",Price=9,CreateDate=DateTimeOffset.UtcNow},
        new Items{ Id=Guid.NewGuid(),Name="Essence Reaver",Price=3700,CreateDate=DateTimeOffset.UtcNow},
        new Items{ Id=Guid.NewGuid(),Name="Blade of the ruined King",Price=4302,CreateDate=DateTimeOffset.UtcNow},


    };

    //Returns all items in the list
    public IEnumerable<Items> GetItems()
    {

        return items;

    }

    //Returns a items based on given id 
    public Items getItem(Guid id)
    {

        return items.Where(items => items.Id == id).SingleOrDefault();
    }

    public void CreateItem(Items item)
    {
        items.Add(item);

    }

    public void UpdateItem(Items item)
    {

        var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
        items[index] = item;
    }

    public void DeleteItem(Guid id)
    {

        var index = items.FindIndex(existingItem => existingItem.Id == id);
        items.RemoveAt(index);


    }
}