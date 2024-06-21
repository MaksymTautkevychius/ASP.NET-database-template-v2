using System.ComponentModel.DataAnnotations;

namespace Test_sample.Models;

public class Character
{
    [Key]
    public int CharactersId { get; set; }
    [Required]
    [MaxLength(100)]
    public string FirstName{ get; set; }
    [Required]
    [MaxLength(100)]
    public string LastName{ get; set; }
    [Required]
    [MaxLength(100)]
    public int CurrentWeil{ get; set; }
    [Required]
    [MaxLength(100)]
    public int MaxWeight{ get; set; }

    public ICollection<Characters_Titles> CharactersTitlesCollection{ get; set; }
    public ICollection<Backpacks> BackpacksCollection{ get; set; }

}