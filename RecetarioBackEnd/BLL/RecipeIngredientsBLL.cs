using RecetarioBackEnd.BLL.Interfaces;
using RecetarioBackEnd.DAL;
using RecetarioBackEnd.DAL.Interfaces;
using RecetarioBackEnd.DTO;
using RecetarioBackEnd.Models;

namespace RecetarioBackEnd.BLL
{
    public class RecipeIngredientsBLL : IRecipeIngredientsBLL
    {
        private readonly IRecipeIngredientsDAL RecipeIngredientsDAL;

        public RecipeIngredientsBLL(IRecipeIngredientsDAL recipeIngredientsDAL)
        {
            RecipeIngredientsDAL = recipeIngredientsDAL;
        }

        public RecipeIngredientDTO? GetRecipeIngredient(int id)
        {
            var recipeIngredient = RecipeIngredientsDAL.GetRecipeIngredient(id);
            if (recipeIngredient == null)
                return null;

            return new RecipeIngredientDTO
            {
                Id = (int)recipeIngredient.Id,
                Ingredient = new IngredientDTO
                {
                    Id = recipeIngredient.Ingredient.Id,
                    IngredientName = recipeIngredient.Ingredient.IngredientName,
                    AmountSoldBy = (float)recipeIngredient.Ingredient.AmountSoldBy,
                    Cost = recipeIngredient.Ingredient.Cost,
                    UnitName = recipeIngredient.Ingredient.Unit.Abbreviation,
                    Efficiency = (float)recipeIngredient.Ingredient.Efficiency,
                    Provider = recipeIngredient.Ingredient.Provider ?? string.Empty
                },
                Quantity = recipeIngredient.Quantity,
                Efficiency = recipeIngredient.Efficiency,
                Cost = recipeIngredient.Quantity * recipeIngredient.Ingredient.Cost / recipeIngredient.Ingredient.AmountSoldBy * recipeIngredient.Efficiency
            };
        }



        public IEnumerable<RecipeIngredientDTO> GetRecipeIngredients(int recipeId)
        {
            var recipeIngredients = RecipeIngredientsDAL.GetRecipeIngredients(recipeId);

            return recipeIngredients.Select(recipeIngredient => new RecipeIngredientDTO
            {
                Ingredient = new IngredientDTO
                {
                    Id = recipeIngredient.Ingredient.Id,
                    IngredientName = recipeIngredient.Ingredient.IngredientName,
                    AmountSoldBy = (float)recipeIngredient.Ingredient.AmountSoldBy,
                    Cost = recipeIngredient.Ingredient.Cost,
                    UnitName = recipeIngredient.Ingredient.Unit.Abbreviation,
                    Efficiency = (float)recipeIngredient.Ingredient.Efficiency,
                    Provider = recipeIngredient.Ingredient.Provider ?? string.Empty
                },
                Quantity = recipeIngredient.Quantity,
                Efficiency = recipeIngredient.Efficiency,
                Cost = recipeIngredient.Quantity * recipeIngredient.Ingredient.Cost / recipeIngredient.Ingredient.AmountSoldBy * recipeIngredient.Efficiency
            });
        }


        public void CreateRecipeIngredient(RecipeIngredientDTO recipeIngredientDTO)
        {
            var recipeIngredient = new RecipeIngredient
            {
                IngredientId = recipeIngredientDTO.Ingredient.Id,
                Quantity = recipeIngredientDTO.Quantity,
                Efficiency = recipeIngredientDTO.Efficiency,
                RecipeId = recipeIngredientDTO.RecipeId
            };

            RecipeIngredientsDAL.CreateRecipeIngredient(recipeIngredient);
        }

        public void UpdateRecipeIngredient(RecipeIngredientDTO recipeIngredientDTO)
        {
            var recipeIngredient = RecipeIngredientsDAL.GetRecipeIngredient((int)recipeIngredientDTO.RecipeId); // TODO
            if (recipeIngredient == null)
                return;

            recipeIngredient.IngredientId = recipeIngredientDTO.Ingredient.Id;
            recipeIngredient.Quantity = recipeIngredientDTO.Quantity;
            recipeIngredient.Efficiency = recipeIngredientDTO.Efficiency;

            RecipeIngredientsDAL.UpdateRecipeIngredient(recipeIngredient);
        }

        public bool IngredientExistsInRecipe(int recipeId, long ingredientId)
        {
            return RecipeIngredientsDAL.GetRecipeIngredients(recipeId).Any(i => i.IngredientId == ingredientId);
        }
    }
}
