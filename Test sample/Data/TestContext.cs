using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Test_sample.Models;

namespace Test_sample.Data;

public partial class TestContext : DbContext
{
    public TestContext()
    {
    }

    public TestContext(DbContextOptions<TestContext> options)
        : base(options)
    {
    }

    public DbSet<Title> Titles{ get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Characters_Titles> CharactersTitlesEnumerable{ get; set; }
    public DbSet<Backpacks> BackpacksEnumerable{ get; set; }
    public DbSet<Character> Characters{ get; set; }
    
}
