using Microsoft.EntityFrameworkCore;
using Test_sample.Data;
using Test_sample.Models;

namespace Test_sample.Services;

public class DbService
{
     readonly TestContext _testContext;

    public DbService(TestContext testContext)
    {
        _testContext = testContext;
    }
    
   public async Task<Character> RetrieveCharacterByiD(int id)
    {
     var character= await  _testContext.Characters
            .Include(e => e.BackpacksCollection)
            .ThenInclude(e => e.Item)
            .Include(e => e.CharactersTitlesCollection)
            .ThenInclude(e => e.Title)
            .Where(e => e.CharactersId == id).FirstAsync();
    
     return character;
    }
    public async Task<Character> RetrieveCharacterByiDWithItmes(int id)
    {
        var character= await  _testContext.Characters
            .Include(e => e.BackpacksCollection)
            .ThenInclude(e => e.Item)
            .Where(e => e.CharactersId == id).FirstAsync();
    
        return character;
    }
}