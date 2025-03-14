using RecetarioBackEnd.Models;

namespace RecetarioBackEnd.DAL.Interfaces
{
    public interface IIngredientsDAL
    {
        void CreateIngredient(Ingredient ingredient);
        IEnumerable<Ingredient> GetAllIngredients();
        Ingredient? GetIngredient(long id);
        void UpdateIngredient(Ingredient ingredient);
    }
}