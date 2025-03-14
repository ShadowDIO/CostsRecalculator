using RecetarioBackEnd.DTO;
using RecetarioBackEnd.Models;

namespace RecetarioBackEnd.BLL.Interfaces
{
    public interface IRecipesBLL
    {
        RecipeDTO? GetRecipe(long recipeId, bool includeUnits = false, bool includeIngredientsAndSubRecipes = false);
        RecipeDTO? MapRecipeModelToDTO(Recipe recipeModel);
        double CalculateRecipeCosts(long recipeId);
        double CalculateRecipeCosts(RecipeDTO recipe);
        RecipeDTO RecalculateRecipe(int recipeId, RecipeRecalculateParametersDTO recalculationParameters);
        RecipeDTO RecalculateRecipe(RecipeDTO recipeDTO, RecipeRecalculateParametersDTO recalculationParameters);
        void UpdateRecipe(RecipeDTO recipeDTO);
        void DeleteRecipeIngredients(int recipeId);
        void CreateRecipeIngredient(RecipeIngredientDTO ingredientDTO);
        void DeleteRecipeSubRecipes(int recipeId);
        void CreateRecipeSubRecipe(RecipeSubRecipeDTO subRecipeDTO);
        int CreateRecipe(RecipeDTO recipeDTO);
        IEnumerable<RecipeDTO> GetAllRecipes(bool includeUnits = false, bool includeIngredientsAndSubRecipes = false);
        IEnumerable<RecipeIngredientDTO> GetRecipeIngredients(int recipeId);
        IEnumerable<RecipeSubRecipeDTO> GetRecipeSubRecipes(int recipeId);
        void DeleteRecipeIngredient(int ingredientId);
        void UpdateRecipeIngredient(RecipeIngredientDTO ingredientDTO);
        void DeleteRecipeSubRecipe(int subRecipeId);
        void UpdateRecipeSubRecipe(RecipeSubRecipeDTO subRecipeDTO);
    }
}