using Microsoft.EntityFrameworkCore;
using RecetarioBackEnd.DAL.Interfaces;
using RecetarioBackEnd.Models;

namespace RecetarioBackEnd.DAL
{
    public class RecipeIngredientsDAL : DALBase, IRecipeIngredientsDAL
    {
        public RecipeIngredientsDAL()
        {
            db = new RecetarioDbContext();
        }

        public RecipeIngredientsDAL(DbContext db)
        {
            this.db = db;
        }

        public RecipeIngredient? GetRecipeIngredient(int id)
        {
            return ((RecetarioDbContext)db).RecipeIngredients.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<RecipeIngredient> GetRecipeIngredients(int recipeId)
        {
            return ((RecetarioDbContext)db).RecipeIngredients.Where(p => p.RecipeId == recipeId);
        }

        public void CreateRecipeIngredient(RecipeIngredient recipeIngredient)
        {
            ((RecetarioDbContext)db).Attach<RecipeIngredient>(recipeIngredient);

            ((RecetarioDbContext)db).Entry(recipeIngredient).State = EntityState.Added;

            ((RecetarioDbContext)db).SaveChanges();
        }

        public void UpdateRecipeIngredient(RecipeIngredient recipeIngredient)
        {
            ((RecetarioDbContext)db).Update(recipeIngredient);

            ((RecetarioDbContext)db).SaveChanges();
        }

        public void DeleteRecipeIngredient(RecipeIngredient recipeIngredient)
        {
            ((RecetarioDbContext)db).RecipeIngredients.Remove(recipeIngredient);

            ((RecetarioDbContext)db).SaveChanges();
        }
    }
}
