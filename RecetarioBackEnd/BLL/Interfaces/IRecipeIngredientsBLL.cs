using RecetarioBackEnd.DTO;

namespace RecetarioBackEnd.BLL.Interfaces
{
    public interface IRecipeIngredientsBLL
    {
        RecipeIngredientDTO? GetRecipeIngredient(int id);
        IEnumerable<RecipeIngredientDTO> GetRecipeIngredients(int recipeId);
        void CreateRecipeIngredient(RecipeIngredientDTO recipeIngredientDTO);
        void UpdateRecipeIngredient(RecipeIngredientDTO recipeIngredientDTO);
        bool IngredientExistsInRecipe(int recipeId, long ingredientId);
    }
}
