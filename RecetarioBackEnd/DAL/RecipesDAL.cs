using Microsoft.EntityFrameworkCore;
using RecetarioBackEnd.DAL.Interfaces;
using RecetarioBackEnd.Models;

namespace RecetarioBackEnd.DAL
{
    public class RecipesDAL : DALBase, IRecipesDAL
    {
        public RecipesDAL()
        {
            db = new RecetarioDbContext();
        }

        public RecipesDAL(DbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Recipe> GetAllRecipes(bool includeUnits = false, bool includeIngredientsAndSubRecipes = false)
        {
            var results = ((RecetarioDbContext)db).Recipes.AsQueryable();

            if (includeUnits)
            {
                results = results.Include(p => p.Unit);
            }

            if(includeIngredientsAndSubRecipes)
            {
                results =  results.Include(p => p.RecipeIngredients)
                                    .ThenInclude(p => p.Ingredient)
                                    .ThenInclude(p => p.Unit)
                    .Include(q => q.RecipeSubRecipeRecipes);
            }

            return results;
        }

        public Recipe? GetRecipe(long id, bool includeUnits = false, bool includeIngredientsAndSubRecipes = false)
        {
            var results = GetAllRecipes(includeUnits, includeIngredientsAndSubRecipes).FirstOrDefault(p => p.Id == id);

            return results;
        }

        public int CreateRecipe(Recipe recipe)
        {
            var results = ((RecetarioDbContext)db).Attach<Recipe>(recipe);

            ((RecetarioDbContext)db).Entry(recipe).State = EntityState.Added;

            ((RecetarioDbContext)db).SaveChanges();

            return (int)results.Entity.Id;
        }

        public void UpdateRecipe(Recipe recipe)
        {
            var existingRecipe = ((RecetarioDbContext)db).Recipes.Find(recipe.Id);

            if (existingRecipe != null)
            {
                db.Entry(existingRecipe).State = EntityState.Detached;
            }

            ((RecetarioDbContext)db).Update(recipe);
            ((RecetarioDbContext)db).SaveChanges();
        }

    }
}
