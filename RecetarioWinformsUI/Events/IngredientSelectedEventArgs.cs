using RecetarioBackEnd.Models;

namespace RecetarioWinformsUI.Events
{
    public class IngredientSelectedEventArgs : EventArgs
    {
        public RecipeIngredient RecipeIngredientSelected { get; private set; }

        public IngredientSelectedEventArgs(RecipeIngredient recipeIngredient)
        {
            RecipeIngredientSelected = recipeIngredient;
        }
    }
}
