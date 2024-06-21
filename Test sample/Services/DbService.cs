using System.Transactions;
using Microsoft.EntityFrameworkCore;
using Test_sample.Controller;
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
    
   public async Task<Character?> RetrieveCharacterByiD(int id)
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

    public async Task<List<Item?>> RetrieveItemsByIds(List<int> ids)
    {
        return await _testContext.Items.Where(i => ids.Contains(i.ItemsId)).ToListAsync();
    }
    public async Task AddItemsToCharacter(int characterId, List<ITemAdd.AddItemDto> items)
    {
        var character = await RetrieveCharacterByiD(characterId);
        if (character == null)
        {
            throw new ArgumentException("no such character");
        }

        var itemIds = items.Select(i => i.ItemId).ToList();
        var existingItems = await RetrieveItemsByIds(itemIds);
        

        var weight = items.Sum(i => existingItems.First(d => d.ItemsId == i.ItemId).Weight * i.Amount);
        var gotWeight = character.BackpacksCollection.Sum(i => i.Item.Weight * i.amount);

        if (gotWeight + weight > character.MaxWeight)
        {
            throw new ArgumentException("not enough weight");
        }
        foreach (var addItem in items)
        {
            var backpackItem = character.BackpacksCollection.FirstOrDefault(i => i.ItemsId == addItem.ItemId);
            if (backpackItem != null)
            {
                backpackItem.amount += addItem.Amount;
            }
            else
            {
                character.BackpacksCollection.Add(new Backpacks()
                {
                    CharacterId = characterId,
                    ItemsId = addItem.ItemId,
                    amount= addItem.Amount
                });
            }
        }
        
        await _testContext.SaveChangesAsync();
    }

       
}