using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Test_sample.Models;


public class Title
{
    [Key]
    public int TitlesId{ get; set; }
    [Required]
    [MaxLength(100)]
    public string Name{ get; set; }
    [MaxLength(100)]
    public int Weight{ get; set; }

    public ICollection<Characters_Titles> CharactersTitlesCollection { get; set; }
}