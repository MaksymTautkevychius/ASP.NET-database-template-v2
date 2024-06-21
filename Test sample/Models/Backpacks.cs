using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Test_sample.Models;

[PrimaryKey(nameof(CharacterId),nameof(ItemsId))]
public class Backpacks
{
    public int CharacterId{ get; set; }
    public int ItemsId{ get; set; }

    [ForeignKey(nameof(CharacterId))]
    public Character Character{ get; set; }
    [ForeignKey(nameof(ItemsId))]
    public Item Item{ get; set; }
    [Required]
    [MaxLength(100)]
    public int amount{ get; set; }
}