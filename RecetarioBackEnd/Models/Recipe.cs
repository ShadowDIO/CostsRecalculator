using System;
using System.Collections.Generic;

namespace RecetarioBackEnd.Models;

public partial class Recipe
{
    public long Id { get; set; }

    public string RecipeName { get; set; } = null!;

    public double Efficiency { get; set; }

    public double AmountProduced { get; set; }

    public long UnitId { get; set; }

    public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();

    public virtual ICollection<RecipeSubRecipe> RecipeSubRecipeRecipes { get; set; } = new List<RecipeSubRecipe>();

    public virtual ICollection<RecipeSubRecipe> RecipeSubRecipeSubRecipes { get; set; } = new List<RecipeSubRecipe>();

    public virtual Unit Unit { get; set; } = null!;
}
