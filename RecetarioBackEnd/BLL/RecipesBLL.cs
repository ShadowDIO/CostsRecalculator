using RecetarioBackEnd.BLL.Interfaces;
using RecetarioBackEnd.DAL.Interfaces;
using RecetarioBackEnd.DTO;
using RecetarioBackEnd.Models;
using System.Linq;

namespace RecetarioBackEnd.BLL
{
    public class RecipesBLL : IRecipesBLL
    {
        private readonly IRecipesDAL RecipesDAL;
        private readonly IRecipeIngredientsDAL RecipeIngredientsDAL;
        private readonly IRecipeSubRecipesDAL RecipeSubRecipesDAL;
        private readonly IIngredientsBLL IngredientsBLL;

        public RecipesBLL(IRecipesDAL recipesDAL, IRecipeIngredientsDAL recipeIngredientsDAL, IRecipeSubRecipesDAL recipeSubRecipesDAL, IIngredientsBLL ingredientsBLL)
        {
            RecipesDAL = recipesDAL;
            RecipeIngredientsDAL = recipeIngredientsDAL;
            RecipeSubRecipesDAL = recipeSubRecipesDAL;
            IngredientsBLL = ingredientsBLL;
        }

        public RecipeDTO? GetRecipe(long recipeId, bool includeUnits = false, bool includeIngredientsAndSubRecipes = false)
        {
            var recipeModel = RecipesDAL.GetRecipe(recipeId, includeUnits, includeIngredientsAndSubRecipes);
            return MapRecipeModelToDTO(recipeModel);
        }

        // Método para mapear un modelo Recipe a un RecipeDTO
        public RecipeDTO? MapRecipeModelToDTO(Recipe? recipeModel)
        {
            if (recipeModel == null)
                return null;

            var recipeDTO = new RecipeDTO()
            {
                Id = recipeModel.Id,
                RecipeName = recipeModel.RecipeName,
                Efficiency = Convert.ToSingle(recipeModel.Efficiency),
                AmountProduced = Convert.ToSingle(recipeModel.AmountProduced),
                UnitId = Convert.ToInt32(recipeModel.UnitId),
                UnitName = recipeModel.Unit?.Abbreviation ?? "Unidad no encontrada",
                Ingredients = recipeModel.RecipeIngredients.Select(p => new RecipeIngredientDTO()
                {
                    Id = (int)p.Id,
                    Ingredient = IngredientsBLL.GetIngredientById(p.IngredientId),
                    Quantity = p.Quantity,
                    Efficiency = p.Efficiency,
                    Cost = (p.Ingredient.Cost / p.Ingredient.AmountSoldBy) * p.Quantity
                }).ToList(),
                SubRecipes = recipeModel.RecipeSubRecipeRecipes.Select(p => new RecipeSubRecipeDTO()
                {
                    Id = (int)p.Id,
                    SubRecipe = MapRecipeModelToDTO(p.SubRecipe),
                    Quantity = p.Quantity,
                    Efficiency = p.Efficiency,
                    Cost = CalculateRecipeCosts((int)p.SubRecipeId)
                }).ToList()
            };

            recipeDTO.Cost = CalculateRecipeCosts(recipeDTO);

            return recipeDTO;
        }

        // Método para mapear un RecipeDTO a un modelo Recipe
        private Recipe MapDTOToRecipeModel(RecipeDTO recipeDTO)
        {
            return new Recipe()
            {
                Id = recipeDTO.Id,
                RecipeName = recipeDTO.RecipeName,
                Efficiency = recipeDTO.Efficiency,
                AmountProduced = recipeDTO.AmountProduced,
                UnitId = recipeDTO.UnitId,
                RecipeIngredients = recipeDTO.Ingredients.Select(p => new RecipeIngredient()
                {
                    IngredientId = p.Ingredient.Id,
                    Quantity = p.Quantity,
                    Efficiency = p.Efficiency
                }).ToList(),
                RecipeSubRecipeRecipes = recipeDTO.SubRecipes.Select(p => new RecipeSubRecipe()
                {
                    SubRecipeId = p.SubRecipe.Id,
                    Quantity = p.Quantity,
                    Efficiency = p.Efficiency
                }).ToList()
            };
        }

        // Recalcular receta por costo
        private RecipeDTO RecalculateRecipeByCost(RecipeDTO recipeDTO, RecipeRecalculateParametersDTO recalculationParameters)
        {
            // By total Recipe Cost by default
            var baseRecipeCost = recipeDTO.Cost;

            var objectiveCost = recalculationParameters.RecalculateValue;

            switch (recalculationParameters.RecalculateOverField)
            {
                case Enums.RecalculateOverFieldEnum.Ingredient:
                    var recipeIngredient = recipeDTO.Ingredients.First(p => (int)p.Ingredient.Id == recalculationParameters.RecalculateFieldId);

                    baseRecipeCost = (recipeIngredient.Ingredient.Cost / recipeIngredient.Ingredient.AmountSoldBy) * recipeIngredient.Quantity;
                    break;
                case Enums.RecalculateOverFieldEnum.SubRecipe:
                    var recipeSubRecipe = recipeDTO.SubRecipes.First(p => (int)p.SubRecipe.Id == recalculationParameters.RecalculateFieldId);

                    baseRecipeCost = CalculateRecipeCosts((int)recipeSubRecipe.SubRecipe.Id);
                    break;
                case Enums.RecalculateOverFieldEnum.Total:
                default:
                    baseRecipeCost = recipeDTO.Cost;
                    break;
            }

            var recalculateFactor = objectiveCost / baseRecipeCost;

            var recalculatedRecipe = new RecipeDTO()
            {
                Id = recipeDTO.Id,
                RecipeName = recipeDTO.RecipeName,
                Efficiency = recipeDTO.Efficiency,
                AmountProduced = Convert.ToSingle(recipeDTO.AmountProduced * recalculateFactor),
                UnitId = recipeDTO.UnitId,
                UnitName = recipeDTO.UnitName,
                Cost = recipeDTO.Cost * recalculateFactor,
                Ingredients = recipeDTO.Ingredients.Select(p =>
                    new RecipeIngredientDTO
                    {
                        Ingredient = p.Ingredient,
                        Quantity = p.Quantity * recalculateFactor,
                        Efficiency = p.Efficiency,
                        Cost = Convert.ToDouble(p.Cost * recalculateFactor)
                    }),
                SubRecipes = recipeDTO.SubRecipes.Select(p =>
                    new RecipeSubRecipeDTO
                    {
                        SubRecipe = p.SubRecipe,
                        Quantity = p.Quantity * recalculateFactor,
                        Efficiency = p.Efficiency,
                        Cost = CalculateRecipeCosts((int)p.SubRecipe.Id) * recalculateFactor
                    })
            };

            return recalculatedRecipe;
        }

        // Recalcular receta por peso
        private RecipeDTO RecalculateRecipeByWeight(RecipeDTO recipeDTO, RecipeRecalculateParametersDTO recalculationParameters)
        {
            // By total Recipe Cost by default
            var baseRecipeCost = recipeDTO.Cost;
            var baseRecipeWeight = recipeDTO.AmountProduced;

            var objectiveWeight = recalculationParameters.RecalculateValue;

            switch (recalculationParameters.RecalculateOverField)
            {
                case Enums.RecalculateOverFieldEnum.Ingredient:
                    var recipeIngredient = recipeDTO.Ingredients.First(p => (int)p.Ingredient.Id == recalculationParameters.RecalculateFieldId);

                    baseRecipeCost = recipeIngredient.Cost;
                    baseRecipeWeight = Convert.ToSingle(recipeIngredient.Quantity);
                    break;
                case Enums.RecalculateOverFieldEnum.SubRecipe:
                    var recipeSubRecipe = recipeDTO.SubRecipes.First(p => (int)p.SubRecipe.Id == recalculationParameters.RecalculateFieldId);

                    baseRecipeCost = CalculateRecipeCosts((int)recipeSubRecipe.SubRecipe.Id);
                    break;
                case Enums.RecalculateOverFieldEnum.Total:
                default:
                    baseRecipeCost = recipeDTO.Cost;
                    baseRecipeWeight = recipeDTO.AmountProduced;
                    break;
            }

            var recalculatedCost = (objectiveWeight * baseRecipeCost) / baseRecipeWeight;

            var recalculateFactor = recalculatedCost / baseRecipeCost;

            var recalculatedRecipe = new RecipeDTO()
            {
                Id = recipeDTO.Id,
                RecipeName = recipeDTO.RecipeName,
                Efficiency = recipeDTO.Efficiency,
                AmountProduced = Convert.ToSingle(recipeDTO.AmountProduced * recalculateFactor),
                UnitId = recipeDTO.UnitId,
                UnitName = recipeDTO.UnitName,
                Cost = recipeDTO.Cost * recalculateFactor,
                Ingredients = recipeDTO.Ingredients.Select(p =>
                     new RecipeIngredientDTO
                     {
                         Ingredient = p.Ingredient,
                         Quantity = p.Quantity * recalculateFactor,
                         Efficiency = p.Efficiency,
                         Cost = Convert.ToDouble(p.Cost * recalculateFactor)
                     }),
                SubRecipes = recipeDTO.SubRecipes.Select(p =>
                    new RecipeSubRecipeDTO
                    {
                        SubRecipe = p.SubRecipe,
                        Quantity = p.Quantity * recalculateFactor,
                        Efficiency = p.Efficiency,
                        Cost = CalculateRecipeCosts((int)p.SubRecipe.Id) * recalculateFactor
                    })
            };

            return recalculatedRecipe;
        }

        // Métodos para calcular costos
        public double CalculateRecipeCosts(long recipeId)
        {
            var recipe = RecipesDAL.GetRecipe(recipeId, includeIngredientsAndSubRecipes: true);
            if (recipe == null) return 0;

            var recipeDTO = MapRecipeModelToDTO(recipe);
            return CalculateRecipeCosts(recipeDTO);
        }

        public double CalculateRecipeCosts(RecipeDTO recipe)
        {
            var ingredientsCosts = CalculateRecipeIngredientsCost(recipe.Ingredients);
            var subRecipesCost = CalculateRecipeSubRecipesCost(recipe.SubRecipes);
            return ingredientsCosts + subRecipesCost;
        }

        private double CalculateRecipeIngredientsCost(IEnumerable<RecipeIngredientDTO> recipeIngredients)
        {
            return recipeIngredients.Sum(ingredient =>
                (ingredient.Ingredient.Cost / ingredient.Ingredient.AmountSoldBy) * ingredient.Quantity);
        }

        private double CalculateRecipeSubRecipesCost(IEnumerable<RecipeSubRecipeDTO> recipeSubRecipes)
        {
            return recipeSubRecipes.Sum(subRecipe => CalculateRecipeCosts(subRecipe.SubRecipe));
        }

        // CRUD: Actualizar receta
        public void UpdateRecipe(RecipeDTO recipeDTO)
        {
            // Mapear solo la información principal de la receta sin incluir las listas de ingredientes y subrecetas
            var recipe = new Recipe()
            {
                Id = recipeDTO.Id,
                RecipeName = recipeDTO.RecipeName,
                Efficiency = recipeDTO.Efficiency,
                AmountProduced = recipeDTO.AmountProduced,
                UnitId = recipeDTO.UnitId
            };

            // Llamar al método de la DAL para actualizar la receta
            RecipesDAL.UpdateRecipe(recipe);
        }


        // CRUD: Eliminar ingredientes de receta
        public void DeleteRecipeIngredients(int recipeId)
        {
            var ingredients = RecipeIngredientsDAL.GetRecipeIngredients(recipeId);
            foreach (var ingredient in ingredients)
            {
                RecipeIngredientsDAL.DeleteRecipeIngredient(ingredient);
            }
        }

        // CRUD: Crear nuevo ingrediente de receta
        public void CreateRecipeIngredient(RecipeIngredientDTO ingredientDTO)
        {
            var ingredient = MapIngredientDTOToModel(ingredientDTO);
            RecipeIngredientsDAL.CreateRecipeIngredient(ingredient);
        }

        // CRUD: Eliminar subrecetas de receta
        public void DeleteRecipeSubRecipes(int recipeId)
        {
            var subRecipes = RecipeSubRecipesDAL.GetRecipeSubRecipes(recipeId);
            foreach (var subRecipe in subRecipes)
            {
                RecipeSubRecipesDAL.DeleteSubRecipe(subRecipe);
            }
        }

        // CRUD: Crear nueva subreceta de receta
        public void CreateRecipeSubRecipe(RecipeSubRecipeDTO subRecipeDTO)
        {
            var subRecipe = MapSubRecipeDTOToModel(subRecipeDTO);
            RecipeSubRecipesDAL.CreateRecipeSubRecipe(subRecipe);
        }

        // Métodos para mapear los DTOs de ingredientes y subrecetas a modelos
        private RecipeIngredient MapIngredientDTOToModel(RecipeIngredientDTO ingredientDTO)
        {
            return new RecipeIngredient()
            {
                Id = ingredientDTO.Id,
                RecipeId = ingredientDTO.RecipeId,
                IngredientId = ingredientDTO.Ingredient.Id,
                Quantity = ingredientDTO.Quantity,
                Efficiency = ingredientDTO.Efficiency
            };
        }

        private RecipeSubRecipe MapSubRecipeDTOToModel(RecipeSubRecipeDTO subRecipeDTO)
        {
            return new RecipeSubRecipe()
            {
                Id = subRecipeDTO.Id,
                RecipeId = subRecipeDTO.RecipeId,
                SubRecipeId = subRecipeDTO.SubRecipe.Id,
                Quantity = subRecipeDTO.Quantity,
                Efficiency = subRecipeDTO.Efficiency
            };
        }

        public RecipeDTO RecalculateRecipe(int recipeId, RecipeRecalculateParametersDTO recalculationParameters)
        {
            // Obtiene la receta por su ID
            var recipeDTO = GetRecipe(recipeId);

            if (recipeDTO == null)
                throw new ArgumentException($"No se encontró la receta con el ID {recipeId}");

            // Llama al segundo método que recalcula basado en el DTO
            return RecalculateRecipe(recipeDTO, recalculationParameters);
        }


        public RecipeDTO RecalculateRecipe(RecipeDTO recipeDTO, RecipeRecalculateParametersDTO recalculationParameters)
        {
            switch (recalculationParameters.RecalculateType)
            {
                case Enums.RecalculateTypeEnum.Weight:
                    return RecalculateRecipeByWeight(recipeDTO, recalculationParameters);
                case Enums.RecalculateTypeEnum.Cost:
                default:
                    return RecalculateRecipeByCost(recipeDTO, recalculationParameters);
            }
        }

        public int CreateRecipe(RecipeDTO recipeDTO)
        {
            var recipe = MapDTOToRecipeModel(recipeDTO);
            return RecipesDAL.CreateRecipe(recipe);
        }

        public IEnumerable<RecipeDTO> GetAllRecipes(bool includeUnits = false, bool includeIngredientsAndSubRecipes = false)
        {
            var recipes = RecipesDAL.GetAllRecipes(includeUnits, includeIngredientsAndSubRecipes);
            return recipes.Select(MapRecipeModelToDTO);
        }

        public IEnumerable<RecipeIngredientDTO> GetRecipeIngredients(int recipeId)
        {
            var ingredients = RecipeIngredientsDAL.GetRecipeIngredients(recipeId);

            return ingredients.Select(p =>
            {

                var fullIngredient = IngredientsBLL.GetIngredientById(p.IngredientId);

                return new RecipeIngredientDTO()
                {
                    Id = (int)fullIngredient.Id,
                    Ingredient = fullIngredient,
                    Quantity = p.Quantity,
                    Efficiency = p.Efficiency,
                    Cost = (fullIngredient.Cost / fullIngredient.AmountSoldBy) * p.Quantity
                };
            });
        }


        public IEnumerable<RecipeSubRecipeDTO> GetRecipeSubRecipes(int recipeId)
        {
            var subRecipes = RecipeSubRecipesDAL.GetRecipeSubRecipes(recipeId);

            return subRecipes.Select(p =>
            {
                // Cargar la subreceta completa
                var fullSubRecipe = MapRecipeModelToDTO(p.SubRecipe);

                return new RecipeSubRecipeDTO()
                {
                    Id = (int)p.Id,
                    SubRecipe = fullSubRecipe,
                    Quantity = p.Quantity,
                    Efficiency = p.Efficiency,
                    Cost = CalculateRecipeCosts((int)p.SubRecipeId)
                };
            });
        }


        // Métodos para eliminar y actualizar ingredientes

        public void DeleteRecipeIngredient(int ingredientId)
        {
            var ingredient = RecipeIngredientsDAL.GetRecipeIngredient(ingredientId);
            if (ingredient != null)
            {
                RecipeIngredientsDAL.DeleteRecipeIngredient(ingredient);
            }
        }

        public void UpdateRecipeIngredient(RecipeIngredientDTO ingredientDTO)
        {
            var ingredient = MapIngredientDTOToModel(ingredientDTO);
            RecipeIngredientsDAL.UpdateRecipeIngredient(ingredient);
        }

        // Métodos para eliminar y actualizar subrecetas

        public void DeleteRecipeSubRecipe(int subRecipeId)
        {
            var subRecipe = RecipeSubRecipesDAL.GetRecipeSubRecipe(subRecipeId);
            if (subRecipe != null)
            {
                RecipeSubRecipesDAL.DeleteSubRecipe(subRecipe);
            }
        }

        public void UpdateRecipeSubRecipe(RecipeSubRecipeDTO subRecipeDTO)
        {
            var subRecipe = MapSubRecipeDTOToModel(subRecipeDTO);
            RecipeSubRecipesDAL.UpdateRecipeSubRecipe(subRecipe);
        }
    }
}
