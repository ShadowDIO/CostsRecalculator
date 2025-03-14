using RecetarioBackEnd.BLL.Interfaces;
using RecetarioBackEnd.DAL.Interfaces;
using RecetarioBackEnd.DTO;
using RecetarioBackEnd.Models;

namespace RecetarioBackEnd.BLL
{
    public class IngredientsBLL : IIngredientsBLL
    {
        private readonly IIngredientsDAL IngredientsDAL;

        public IngredientsBLL(IIngredientsDAL ingredientsDAL)
        {
            IngredientsDAL = ingredientsDAL;
        }

        public void CreateIngredient(IngredientDTO ingredientDTO)
        {

            var ingredient = new Ingredient
            {
                IngredientName = ingredientDTO.IngredientName,
                Cost = ingredientDTO.Cost,
                AmountSoldBy = ingredientDTO.AmountSoldBy,
                Efficiency = ingredientDTO.Efficiency,
                UnitId = ingredientDTO.UnitId,
                Provider = ingredientDTO.Provider
            };

            IngredientsDAL.CreateIngredient(ingredient);
        }

        public void UpdateIngredient(IngredientDTO ingredientDTO)
        {
            var existingIngredient = IngredientsDAL.GetIngredient(ingredientDTO.Id);
            if (existingIngredient == null)
            {
                throw new KeyNotFoundException($"Ingrediente con ID {ingredientDTO.Id} no encontrado.");
            }

            existingIngredient.IngredientName = ingredientDTO.IngredientName;
            existingIngredient.Cost = ingredientDTO.Cost;
            existingIngredient.AmountSoldBy = ingredientDTO.AmountSoldBy;
            existingIngredient.Efficiency = ingredientDTO.Efficiency;
            existingIngredient.UnitId = ingredientDTO.UnitId;
            existingIngredient.Provider = ingredientDTO.Provider;

            IngredientsDAL.UpdateIngredient(existingIngredient);
        }

        public IngredientDTO? GetIngredientById(long id)
        {
            var ingredient = IngredientsDAL.GetIngredient(id);
            if (ingredient == null)
            {
                return null;
            }

            return new IngredientDTO
            {
                Id = ingredient.Id,
                IngredientName = ingredient.IngredientName,
                Cost = ingredient.Cost,
                AmountSoldBy = ingredient.AmountSoldBy,
                Efficiency = ingredient.Efficiency,
                UnitId = ingredient.UnitId,
                UnitName = ingredient.Unit?.Abbreviation ?? string.Empty,
                Provider = ingredient.Provider
            };
        }

        public IEnumerable<IngredientDTO> GetAllIngredients()
        {
            var ingredients = IngredientsDAL.GetAllIngredients();
            return ingredients.Select(ingredient => new IngredientDTO
            {
                Id = ingredient.Id,
                IngredientName = ingredient.IngredientName,
                Cost = ingredient.Cost,
                AmountSoldBy = ingredient.AmountSoldBy,
                Efficiency = ingredient.Efficiency,
                UnitId = ingredient.UnitId,
                UnitName = ingredient.Unit?.Abbreviation ?? string.Empty,
                Provider = ingredient.Provider
            }).ToList();
        }
    }
}
