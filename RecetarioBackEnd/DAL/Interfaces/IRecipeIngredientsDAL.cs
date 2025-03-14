using RecetarioBackEnd.Models;

namespace RecetarioBackEnd.DAL.Interfaces
{
    public interface IRecipeIngredientsDAL
    {
        void CreateRecipeIngredient(RecipeIngredient recipeIngredient);
        RecipeIngredient? GetRecipeIngredient(int id);
        IEnumerable<RecipeIngredient> GetRecipeIngredients(int recipeId);
        void UpdateRecipeIngredient(RecipeIngredient recipeIngredient);
        void DeleteRecipeIngredient(RecipeIngredient recipeIngredient);
    }
}