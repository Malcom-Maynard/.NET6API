namespace API.Dtos;
using System.ComponentModel.DataAnnotations;

public class UpdateItemDto
{
    //Data annotation for the items
    [Required]
    public string Name { get; init; }
    [Required]
    [Range(1, 9000)]
    public decimal Price { get; init; }

}