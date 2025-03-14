using RecetarioBackEnd.Models;

namespace RecetarioBackEnd.DAL.Interfaces
{
    public interface IRecipesDAL
    {
        int CreateRecipe(Recipe recipe);
        IEnumerable<Recipe> GetAllRecipes(bool includeUnits = false, bool includeIngredientsAndSubRecipes = false);
        Recipe? GetRecipe(long id, bool includeUnits = false, bool includeIngredientsAndSubRecipes = false);
        void UpdateRecipe(Recipe recipe);
    }
}