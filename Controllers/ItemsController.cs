namespace API.Controllers;
using Microsoft.AspNetCore.Mvc;
using API.Repositories;
using API.Entities;
using API.Dtos;
using API;

[ApiController]
[Route("items")]
public class ItemsController : ControllerBase
{

    //Calling the repo of items
    private readonly IinMemitemsRespository repository;

    //Defining Dependency Injection for the repository 
    public ItemsController(IinMemitemsRespository repository)
    {

        this.repository = repository;


    }


    //returns list of items to the user, GET METHOD
    [HttpGet]
    public IEnumerable<ItemDto> GetItems()
    {


        var items = repository.GetItems().Select(item => item.AsDto());


        return items;



    }
    //Get /items/{id}
    [HttpGet("{id}")]
    public ActionResult<ItemDto> GetItem(Guid id)
    {


        var item = repository.getItem(id);

        if (item is null)
        {
            return NotFound();
        }
        return item.AsDto();



    }
    //POST /items
    //Passes arguments through Swagger, defined in DTO/ function argument
    //Returns the created object
    [HttpPost]
    public ActionResult<ItemDto> createItem(CreateItemDto itemDto)
    {


        Items item = new()
        {

            Id = Guid.NewGuid(),
            Name = itemDto.Name,
            Price = itemDto.Price,
            CreateDate = DateTimeOffset.UtcNow
        };

        repository.CreateItem(item);

        return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.AsDto());
    }

    //Put /items/{id}
    [HttpPut("{id}")]
    public ActionResult UpdateItem(Guid id, UpdateItemDto itemDto)
    {
        var existingItem = repository.getItem(id);

        if (existingItem is null)
        {

            return NotFound();
        }

        Items UpdatedItem = existingItem with
        {

            Name = itemDto.Name,
            Price = itemDto.Price,
        };

        repository.UpdateItem(UpdatedItem);
        return NoContent();
    }

    //DELETE index/{id}
    [HttpDelete("{id}")]
    public ActionResult DeleteItem(Guid id)
    {
        var existingItem = repository.getItem(id);

        if (existingItem is null)
        {

            return NotFound();
        }

        repository.DeleteItem(id);
        return NoContent();

    }
}
