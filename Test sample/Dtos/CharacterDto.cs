namespace Test_sample.Controller;

public class CharacterDto
{
    public int CharactersId { get; set; }

    public string FirstName{ get; set; }
    
    public string LastName{ get; set; }

    public int CurrentWei{ get; set; }

    public int MaxWeight{ get; set; }

    public ICollection<TitlesDto> TitlesDto { get; set; }
    public ICollection<ItemdTO> ItemdTos;
}
public class TitlesDto{

    public string Name{ get; set; }
    public int Weight{ get; set; }
}

public class ItemdTO
{
    public string Name{ get; set; }
    public int Weight{ get; set; }
    public int amount { get; set; }
}