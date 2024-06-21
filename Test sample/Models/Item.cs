using System.ComponentModel.DataAnnotations;

namespace Test_sample.Models;


public class Item
{
    [Key]
    public int ItemsId { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name{ get; set; }
    [MaxLength(100)]
    public int Weight{ get; set; }

    public ICollection<Backpacks> BackpacksCollection{ get; set; }

}