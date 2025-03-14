using RecetarioBackEnd.DTO;

namespace RecetarioBackEnd.BLL.Interfaces
{
    public interface IIngredientsBLL
    {
        void CreateIngredient(IngredientDTO ingredientDTO);
        void UpdateIngredient(IngredientDTO ingredientDTO);
        IngredientDTO? GetIngredientById(long id);
        IEnumerable<IngredientDTO> GetAllIngredients();
    }
}