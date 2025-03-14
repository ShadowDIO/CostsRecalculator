using RecetarioBackEnd.Models;

namespace RecetarioWinformsUI.Events
{
    public class SubRecipeSelectedEventArgs : EventArgs
    {
        public RecipeSubRecipe SubRecipe { get; private set; }

        public SubRecipeSelectedEventArgs(RecipeSubRecipe subRecipe)
        {
            SubRecipe = subRecipe;
        }
    }
}
