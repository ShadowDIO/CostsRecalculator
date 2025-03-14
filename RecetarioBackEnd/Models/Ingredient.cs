using System;
using System.Collections.Generic;

namespace RecetarioBackEnd.Models;

public partial class Ingredient
{
    public long Id { get; set; }

    public string IngredientName { get; set; } = null!;

    public double AmountSoldBy { get; set; }

    public double Cost { get; set; }

    public long UnitId { get; set; }

    public double Efficiency { get; set; }

    public string? Provider { get; set; }

    public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();

    public virtual Unit Unit { get; set; } = null!;
}
