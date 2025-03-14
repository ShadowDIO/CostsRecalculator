using Microsoft.EntityFrameworkCore;
using RecetarioBackEnd.DAL.Interfaces;
using RecetarioBackEnd.Models;

namespace RecetarioBackEnd.DAL
{
    public class RecipeSubRecipesDAL : DALBase, IRecipeSubRecipesDAL
    {
        public RecipeSubRecipesDAL()
        {
            db = new RecetarioDbContext();
        }

        public RecipeSubRecipesDAL(DbContext db)
        {
            this.db = db;
        }

        public RecipeSubRecipe? GetRecipeSubRecipe(int id)
        {
            return ((RecetarioDbContext)db).RecipeSubRecipes.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<RecipeSubRecipe> GetRecipeSubRecipes(int recipeId)
        {
            return ((RecetarioDbContext)db).RecipeSubRecipes
                    .Include(p => p.SubRecipe) // Incluye la subreceta completa
                    .Include(p => p.Recipe)    // Incluye la receta principal si también es necesario
                    .Where(p => p.RecipeId == recipeId);
        }

        public void CreateRecipeSubRecipe(RecipeSubRecipe recipeSubRecipe)
        {
            ((RecetarioDbContext)db).Attach<RecipeSubRecipe>(recipeSubRecipe);

            ((RecetarioDbContext)db).Entry(recipeSubRecipe).State = EntityState.Added;

            ((RecetarioDbContext)db).SaveChanges();
        }

        public void UpdateRecipeSubRecipe(RecipeSubRecipe recipeSubRecipe)
        {
            ((RecetarioDbContext)db).Update(recipeSubRecipe);

            ((RecetarioDbContext)db).SaveChanges();
        }

        public void DeleteSubRecipe(RecipeSubRecipe recipeSubRecipe)
        {
            ((RecetarioDbContext)db).Remove(recipeSubRecipe);

            ((RecetarioDbContext)db).SaveChanges();
        }
    }
}
