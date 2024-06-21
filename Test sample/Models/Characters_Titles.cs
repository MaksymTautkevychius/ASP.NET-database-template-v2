using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Test_sample.Models;
[PrimaryKey(nameof(CharacterId),nameof(TitlesId))]
public class Characters_Titles
{
    
    public int CharacterId{ get; set; }
    public int TitlesId{ get; set; }
    [ForeignKey(nameof(CharacterId))]
    public Character Character { get; set; }
    [ForeignKey(nameof(TitlesId))]
    public Title Title{ get; set; }
}