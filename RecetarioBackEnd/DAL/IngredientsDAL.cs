using Microsoft.EntityFrameworkCore;
using RecetarioBackEnd.DAL.Interfaces;
using RecetarioBackEnd.Models;

namespace RecetarioBackEnd.DAL
{
    public class IngredientsDAL : DALBase, IIngredientsDAL
    {
        public IngredientsDAL()
        {
            db = new RecetarioDbContext();
        }

        public IngredientsDAL(DbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Ingredient> GetAllIngredients()
        {
            return ((RecetarioDbContext)db).Ingredients.Include(p => p.Unit);
        }

        public Ingredient? GetIngredient(long id)
        {
            return ((RecetarioDbContext)db).Ingredients
                .Include(p => p.Unit).FirstOrDefault(p => p.Id == id);
        }

        public void CreateIngredient(Ingredient ingredient)
        {
            ((RecetarioDbContext)db).Add<Ingredient>(ingredient);

            ((RecetarioDbContext)db).SaveChanges();
        }

        public void UpdateIngredient(Ingredient ingredient)
        {
            ((RecetarioDbContext)db).Update(ingredient);

            ((RecetarioDbContext)db).SaveChanges();
        }
    }
}
