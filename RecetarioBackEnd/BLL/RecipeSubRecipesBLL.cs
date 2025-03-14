using RecetarioBackEnd.BLL.Interfaces;
using RecetarioBackEnd.DAL;
using RecetarioBackEnd.DAL.Interfaces;
using RecetarioBackEnd.DTO;
using RecetarioBackEnd.Models;

namespace RecetarioBackEnd.BLL
{
    public class RecipeSubRecipesBLL : IRecipeSubRecipesBLL
    {
        private readonly IRecipeSubRecipesDAL RecipeSubRecipesDAL;

        public RecipeSubRecipesBLL(IRecipeSubRecipesDAL recipeSubRecipesDAL)
        {
            RecipeSubRecipesDAL = recipeSubRecipesDAL;
        }

        public RecipeSubRecipeDTO? GetRecipeSubRecipe(int id)
        {
            var recipeSubRecipe = RecipeSubRecipesDAL.GetRecipeSubRecipe(id);
            if (recipeSubRecipe == null)
                return null;

            return new RecipeSubRecipeDTO
            {
                SubRecipe = new RecipeDTO
                {
                    Id = recipeSubRecipe.SubRecipe.Id,
                    RecipeName = recipeSubRecipe.SubRecipe.RecipeName,
                    Efficiency = (float)recipeSubRecipe.SubRecipe.Efficiency,
                    AmountProduced = (float)recipeSubRecipe.SubRecipe.AmountProduced,
                    UnitId = (int)recipeSubRecipe.SubRecipe.UnitId,
                    UnitName = recipeSubRecipe.SubRecipe.Unit.Name,
                    //Cost = recipeSubRecipe.SubRecipe.Cost, TO DO
                    Ingredients = recipeSubRecipe.SubRecipe.RecipeIngredients.Select(ingredient => new RecipeIngredientDTO
                    {
                        Ingredient = new IngredientDTO
                        {
                            Id = ingredient.Ingredient.Id,
                            IngredientName = ingredient.Ingredient.IngredientName,
                            AmountSoldBy = (float)ingredient.Ingredient.AmountSoldBy,
                            Cost = ingredient.Ingredient.Cost,
                            UnitName = ingredient.Ingredient.Unit.Abbreviation,
                            Efficiency = (float)ingredient.Ingredient.Efficiency,
                            Provider = ingredient.Ingredient.Provider ?? string.Empty
                        },
                        Quantity = ingredient.Quantity,
                        Efficiency = ingredient.Efficiency,
                        Cost = ingredient.Quantity * ingredient.Ingredient.Cost / ingredient.Ingredient.AmountSoldBy * ingredient.Efficiency
                    }).ToList(),
                    SubRecipes = recipeSubRecipe.SubRecipe.RecipeSubRecipeSubRecipes.Select(subRecipe => new RecipeSubRecipeDTO
                    {
                        SubRecipe = new RecipeDTO
                        {
                            Id = subRecipe.SubRecipe.Id,
                            RecipeName = subRecipe.SubRecipe.RecipeName,
                            Efficiency = (float)subRecipe.SubRecipe.Efficiency,
                            AmountProduced = (float)subRecipe.SubRecipe.AmountProduced,
                            UnitId = (int)subRecipe.SubRecipe.UnitId,
                            UnitName = subRecipe.SubRecipe.Unit.Name,
                            //Cost = subRecipe.SubRecipe.Cost TO DO
                        },
                        Quantity = subRecipe.Quantity,
                        Efficiency = subRecipe.Efficiency,
                        //Cost = subRecipe.Quantity * subRecipe.SubRecipe.Cost / subRecipe.SubRecipe.AmountProduced * subRecipe.Efficiency to do
                    }).ToList()
                },
                Quantity = recipeSubRecipe.Quantity,
                Efficiency = recipeSubRecipe.Efficiency,
                //Cost = recipeSubRecipe.Quantity * recipeSubRecipe.SubRecipe.Cost / recipeSubRecipe.SubRecipe.AmountProduced * recipeSubRecipe.Efficiency
            };
        }


        public IEnumerable<RecipeSubRecipeDTO> GetRecipeSubRecipes(int recipeId)
        {
            var recipeSubRecipes = RecipeSubRecipesDAL.GetRecipeSubRecipes(recipeId);

            return recipeSubRecipes.Select(recipeSubRecipe => new RecipeSubRecipeDTO
            {
                SubRecipe = new RecipeDTO
                {
                    Id = recipeSubRecipe.SubRecipe.Id,
                    RecipeName = recipeSubRecipe.SubRecipe.RecipeName,
                    Efficiency = (float)recipeSubRecipe.SubRecipe.Efficiency,
                    AmountProduced = (float)recipeSubRecipe.SubRecipe.AmountProduced,
                    UnitId = (int)recipeSubRecipe.SubRecipe.UnitId,
                    UnitName = recipeSubRecipe.SubRecipe.Unit.Name,
                    //Cost = recipeSubRecipe.SubRecipe.Cost,
                    Ingredients = recipeSubRecipe.SubRecipe.RecipeIngredients.Select(ingredient => new RecipeIngredientDTO
                    {
                        Ingredient = new IngredientDTO
                        {
                            Id = ingredient.Ingredient.Id,
                            IngredientName = ingredient.Ingredient.IngredientName,
                            AmountSoldBy = (float)ingredient.Ingredient.AmountSoldBy,
                            Cost = ingredient.Ingredient.Cost,
                            UnitName = ingredient.Ingredient.Unit.Abbreviation,
                            Efficiency = (float)ingredient.Ingredient.Efficiency,
                            Provider = ingredient.Ingredient.Provider ?? string.Empty
                        },
                        Quantity = ingredient.Quantity,
                        Efficiency = ingredient.Efficiency,
                        Cost = ingredient.Quantity * ingredient.Ingredient.Cost / ingredient.Ingredient.AmountSoldBy * ingredient.Efficiency
                    }).ToList(),
                    SubRecipes = recipeSubRecipe.SubRecipe.RecipeSubRecipeSubRecipes.Select(subRecipe => new RecipeSubRecipeDTO
                    {
                        SubRecipe = new RecipeDTO
                        {
                            Id = subRecipe.SubRecipe.Id,
                            RecipeName = subRecipe.SubRecipe.RecipeName,
                            Efficiency = (float)subRecipe.SubRecipe.Efficiency,
                            AmountProduced = (float)subRecipe.SubRecipe.AmountProduced,
                            UnitId = (int)subRecipe.SubRecipe.UnitId,
                            UnitName = subRecipe.SubRecipe.Unit.Name,
                            //Cost = subRecipe.SubRecipe.Cost
                        },
                        Quantity = subRecipe.Quantity,
                        Efficiency = subRecipe.Efficiency,
                        //Cost = subRecipe.Quantity * subRecipe.SubRecipe.Cost / subRecipe.SubRecipe.AmountProduced * subRecipe.Efficiency
                    }).ToList()
                },
                Quantity = recipeSubRecipe.Quantity,
                Efficiency = recipeSubRecipe.Efficiency,
                //Cost = recipeSubRecipe.Quantity * recipeSubRecipe.SubRecipe.Cost / recipeSubRecipe.SubRecipe.AmountProduced * recipeSubRecipe.Efficiency
            });
        }


        public void CreateRecipeSubRecipe(RecipeSubRecipeDTO recipeSubRecipeDTO)
        {
            var recipeSubRecipe = new RecipeSubRecipe
            {
                SubRecipeId = recipeSubRecipeDTO.SubRecipe.Id,
                Quantity = recipeSubRecipeDTO.Quantity,
                Efficiency = recipeSubRecipeDTO.Efficiency
            };

            RecipeSubRecipesDAL.CreateRecipeSubRecipe(recipeSubRecipe);
        }

        public void UpdateRecipeSubRecipe(RecipeSubRecipeDTO recipeSubRecipeDTO)
        {
            var recipeSubRecipe = RecipeSubRecipesDAL.GetRecipeSubRecipe((int)recipeSubRecipeDTO.SubRecipeId);
            if (recipeSubRecipe == null)
                return;

            recipeSubRecipe.SubRecipeId = recipeSubRecipeDTO.SubRecipe.Id;
            recipeSubRecipe.Quantity = recipeSubRecipeDTO.Quantity;
            recipeSubRecipe.Efficiency = recipeSubRecipeDTO.Efficiency;

            RecipeSubRecipesDAL.UpdateRecipeSubRecipe(recipeSubRecipe);
        }

        public bool SubRecipeExistsInRecipe(int recipeId, long subRecipeId)
        {
            return RecipeSubRecipesDAL.GetRecipeSubRecipes(recipeId).Any(sr => sr.SubRecipeId == subRecipeId);
        }
    }
}
