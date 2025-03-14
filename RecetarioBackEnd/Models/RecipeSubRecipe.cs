using System;
using System.Collections.Generic;

namespace RecetarioBackEnd.Models;

public partial class RecipeSubRecipe
{
    public long Id { get; set; }

    public long SubRecipeId { get; set; }

    public long RecipeId { get; set; }

    public double Quantity { get; set; }

    public double Efficiency { get; set; }

    public virtual Recipe Recipe { get; set; } = null!;

    public virtual Recipe SubRecipe { get; set; } = null!;
}
