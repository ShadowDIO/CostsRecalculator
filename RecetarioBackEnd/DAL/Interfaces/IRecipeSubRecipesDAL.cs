using RecetarioBackEnd.Models;

namespace RecetarioBackEnd.DAL.Interfaces
{
    public interface IRecipeSubRecipesDAL
    {
        void CreateRecipeSubRecipe(RecipeSubRecipe recipeSubRecipe);
        RecipeSubRecipe? GetRecipeSubRecipe(int id);
        IEnumerable<RecipeSubRecipe> GetRecipeSubRecipes(int recipeId);
        void UpdateRecipeSubRecipe(RecipeSubRecipe recipeSubRecipe);
        void DeleteSubRecipe(RecipeSubRecipe recipeSubRecipe);
    }
}