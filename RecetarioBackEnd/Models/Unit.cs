using System;
using System.Collections.Generic;

namespace RecetarioBackEnd.Models;

public partial class Unit
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string Abbreviation { get; set; } = null!;

    public virtual ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
}
