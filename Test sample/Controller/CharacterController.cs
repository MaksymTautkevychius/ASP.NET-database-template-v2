
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Test_sample.Services;

namespace Test_sample.Controller;

public class CharacterController : ControllerBase
{
    private readonly DbService _dbService;

    public CharacterController(DbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("api/characters/{id}")]
    public async Task<IActionResult> GetCharacterWithId(int id)
    {
        var  characterByiD = await _dbService.RetrieveCharacterByiD(id);
        if (characterByiD == null)
        {
            BadRequest("NO SUCH CHARACTER");
        }
       
        var characterDto = new CharacterDto
        {
            FirstName = characterByiD.FirstName,
            LastName = characterByiD.LastName,
            MaxWeight = characterByiD.MaxWeight,
            CurrentWei = characterByiD.CurrentWeil,
            TitlesDto = characterByiD.CharactersTitlesCollection.Select(ct => new TitlesDto
            {
                Name = ct.Title.Name,
                Weight = ct.Title.Weight
            }).ToList(),
            ItemdTos = characterByiD.BackpacksCollection.Select(ct=> new ItemdTO
            {
                amount = ct.amount,
                Name = ct.Item.Name,
                Weight = ct.Item.Weight,
            }).ToList()
        };
        return Ok(characterDto);
    }
    [HttpPost("api/characters/{id}/backpacks")]
    public async Task<IActionResult> UpdateItems(int id)
    {
        var  characterByiD = await _dbService.RetrieveCharacterByiD(id);
        if (characterByiD == null)
        {
            BadRequest("NO SUCH CHARACTER");
        }
       
        var characterDto = new CharacterDto
        {
            
            
            ItemdTos = characterByiD.BackpacksCollection.Select(ct=> new ItemdTO
            {
                amount = ct.amount,
                Name = ct.Item.Name,
                Weight = ct.Item.Weight,
            }).ToList()
        };
        return Ok(characterDto);
    }

  
    
}