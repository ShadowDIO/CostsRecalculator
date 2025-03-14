using RecetarioBackEnd.DTO;

namespace RecetarioBackEnd.BLL.Interfaces
{
    public interface IRecipeSubRecipesBLL
    {
        RecipeSubRecipeDTO? GetRecipeSubRecipe(int id);
        IEnumerable<RecipeSubRecipeDTO> GetRecipeSubRecipes(int recipeId);
        void CreateRecipeSubRecipe(RecipeSubRecipeDTO recipeSubRecipeDTO);
        void UpdateRecipeSubRecipe(RecipeSubRecipeDTO recipeSubRecipeDTO);
        bool SubRecipeExistsInRecipe(int recipeId, long subRecipeId);
    }
}
