namespace API.Repositories;
using API.Repositories;
using API.Entities;


// Creaitng Interface that will be used for Dependency Injection 
public interface IinMemitemsRespository
{
    Items getItem(Guid id);
    IEnumerable<Items> GetItems();

    void CreateItem(Items items);

    void UpdateItem(Items item);

    void DeleteItem(Guid id);
}