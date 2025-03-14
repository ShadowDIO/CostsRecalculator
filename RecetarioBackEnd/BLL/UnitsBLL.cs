using RecetarioBackEnd.BLL.Interfaces;
using RecetarioBackEnd.DAL.Interfaces;
using RecetarioBackEnd.DTO;
using RecetarioBackEnd.Models;

namespace RecetarioBackEnd.BLL
{
    public class UnitsBLL : IUnitsBLL
    {
        private readonly IUnitsDAL UnitsDAL;

        public UnitsBLL(IUnitsDAL unitsDAL)
        {
            UnitsDAL = unitsDAL;
        }

        public IEnumerable<UnitDTO> GetAllUnits()
        {
            var units = UnitsDAL.GetAllUnits();
            return units.Select(unit => new UnitDTO
            {
                Id = unit.Id,
                Abbreviation = unit.Abbreviation,
                Name = unit.Name,
                Ingredients = unit.Ingredients.Select(ingredient => new IngredientDTO
                {
                    Id = ingredient.Id,
                    IngredientName = ingredient.IngredientName,
                    AmountSoldBy = (float)ingredient.AmountSoldBy,
                    Cost = ingredient.Cost,
                    UnitName = ingredient.Unit.Abbreviation,
                    Efficiency = (float)ingredient.Efficiency,
                    Provider = ingredient.Provider ?? string.Empty
                }).ToList(),
                Recipes = unit.Recipes.Select(recipe => new RecipeDTO
                {
                    Id = recipe.Id,
                    RecipeName = recipe.RecipeName,
                    Efficiency = (float)recipe.Efficiency,
                    AmountProduced = (float)recipe.AmountProduced,
                    UnitId = (int)recipe.UnitId,
                    UnitName = recipe.Unit.Name,
                }).ToList()
            });
        }

        public UnitDTO? GetUnit(int id)
        {
            var unit = UnitsDAL.GetUnit(id);
            if (unit == null)
                return null;

            return new UnitDTO
            {
                Id = unit.Id,
                Abbreviation = unit.Abbreviation,
                Name = unit.Name,
                Ingredients = unit.Ingredients.Select(ingredient => new IngredientDTO
                {
                    Id = ingredient.Id,
                    IngredientName = ingredient.IngredientName,
                    AmountSoldBy = (float)ingredient.AmountSoldBy,
                    Cost = ingredient.Cost,
                    UnitName = ingredient.Unit.Abbreviation,
                    Efficiency = (float)ingredient.Efficiency,
                    Provider = ingredient.Provider ?? string.Empty
                }).ToList(),
                Recipes = unit.Recipes.Select(recipe => new RecipeDTO
                {
                    Id = recipe.Id,
                    RecipeName = recipe.RecipeName,
                    Efficiency = (float)recipe.Efficiency,
                    AmountProduced = (float)recipe.AmountProduced,
                    UnitId = (int)recipe.UnitId,
                    UnitName = recipe.Unit.Name,
                }).ToList()
            };
        }

        public UnitDTO? GetUnit(string abbreviation)
        {
            var unit = UnitsDAL.GetUnit(abbreviation);
            if (unit == null)
                return null;

            return new UnitDTO
            {
                Id = unit.Id,
                Abbreviation = unit.Abbreviation,
                Name = unit.Name,
                Ingredients = unit.Ingredients.Select(ingredient => new IngredientDTO
                {
                    Id = ingredient.Id,
                    IngredientName = ingredient.IngredientName,
                    AmountSoldBy = (float)ingredient.AmountSoldBy,
                    Cost = ingredient.Cost,
                    UnitName = ingredient.Unit.Abbreviation,
                    Efficiency = (float)ingredient.Efficiency,
                    Provider = ingredient.Provider ?? string.Empty
                }).ToList(),
                Recipes = unit.Recipes.Select(recipe => new RecipeDTO
                {
                    Id = recipe.Id,
                    RecipeName = recipe.RecipeName,
                    Efficiency = (float)recipe.Efficiency,
                    AmountProduced = (float)recipe.AmountProduced,
                    UnitId = (int)recipe.UnitId,
                    UnitName = recipe.Unit.Name,
                }).ToList()
            };
        }

        public void CreateUnit(UnitDTO unitDTO)
        {
            var unit = new Unit
            {
                Abbreviation = unitDTO.Abbreviation,
                Name = unitDTO.Name
            };

            UnitsDAL.CreateUnit(unit);
        }

        public void UpdateUnit(UnitDTO unitDTO)
        {
            var unit = UnitsDAL.GetUnit((int)unitDTO.Id);
            if (unit == null)
                return;

            unit.Abbreviation = unitDTO.Abbreviation;
            unit.Name = unitDTO.Name;

            UnitsDAL.UpdateUnit(unit);
        }
    }
}
