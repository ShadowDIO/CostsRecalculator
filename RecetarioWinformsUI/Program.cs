using RecetarioBackEnd.BLL;
using RecetarioBackEnd.BLL.Interfaces;
using RecetarioBackEnd.DAL;
using RecetarioBackEnd.DAL.Interfaces;
using RecetarioWinformsUI.Main;

namespace RecetarioWinformsUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IIngredientsDAL ingredientsDAL = new IngredientsDAL();
            IUnitsDAL unitsDAL = new UnitsDAL();
            IRecipesDAL recipesDAL = new RecipesDAL();
            IRecipeIngredientsDAL recipeIngredientsDAL = new RecipeIngredientsDAL();
            IRecipeSubRecipesDAL recipeSubRecipesDAL = new RecipeSubRecipesDAL();

            IIngredientsBLL ingredientsBLL = new IngredientsBLL(ingredientsDAL);
            IUnitsBLL unitsBLL = new UnitsBLL(unitsDAL);
            IRecipesBLL recipesBLL = new RecipesBLL(recipesDAL, recipeIngredientsDAL, recipeSubRecipesDAL, ingredientsBLL);
            IRecipeIngredientsBLL recipeIngredientsBLL = new RecipeIngredientsBLL(recipeIngredientsDAL);
            IRecipeSubRecipesBLL recipeSubRecipesBLL = new RecipeSubRecipesBLL(recipeSubRecipesDAL);

            ApplicationConfiguration.Initialize();
            Application.Run(new MainWindow(ingredientsBLL, unitsBLL, recipesBLL, recipeIngredientsBLL, recipeSubRecipesBLL));
        }
    }
}
