using System;
using System.Collections.Generic;

namespace RecetarioBackEnd.Models;

public partial class RecipeIngredient
{
    public long Id { get; set; }

    public long RecipeId { get; set; }

    public long IngredientId { get; set; }

    public double Quantity { get; set; }

    public double Efficiency { get; set; }

    public virtual Ingredient Ingredient { get; set; } = null!;

    public virtual Recipe Recipe { get; set; } = null!;
}
