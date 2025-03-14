namespace RecetarioWinformsUI.Events
{
    internal class GlobalUIEvents
    {
        public static GlobalUIEvents Instance = new GlobalUIEvents();

        private GlobalUIEvents() { }

        #region Units

        public delegate void UnitAddedDelegate(object sender, EventArgs e);
        public event UnitAddedDelegate? OnUnitAdded;

        public delegate void UnitUpdatedDelegate(object sender, EventArgs e);
        public event UnitUpdatedDelegate? OnUnitUpdated;

        public void DispatchOnUnitAdded(object sender, EventArgs e)
        {
            Instance.OnUnitAdded?.Invoke(sender, e);
        }
        
        public void DispatchOnUnitUpdated(object sender, EventArgs e)
        {
            Instance.OnUnitUpdated?.Invoke(sender, e);
        }

        #endregion

        #region Ingredients
        
        public delegate void IngredientAddedDelegate(object sender, EventArgs e);
        public event IngredientAddedDelegate? OnIngredientAdded;

        public delegate void IngredientUpdatedDelegate(object sender, EventArgs e);
        public event IngredientUpdatedDelegate? OnIngredientUpdated;

        public void DispatchOnIngredientAdded(object sender, EventArgs e)
        {
            Instance.OnIngredientAdded?.Invoke(sender, e);
        }

        public void DispatchOnIngredientUpdated(object sender, EventArgs e)
        {
            Instance.OnIngredientUpdated?.Invoke(sender, e);
        }

        #endregion


        #region Recipes

        public delegate void RecipeAddedDelegate(object sender, EventArgs e);
        public event RecipeAddedDelegate? OnRecipeAdded;

        public delegate void RecipeUpdatedDelegate(object sender, EventArgs e);
        public event RecipeUpdatedDelegate? OnRecipeUpdated;

        public void DispatchOnRecipeAdded(object sender, EventArgs e)
        {
            Instance.OnRecipeAdded?.Invoke(sender, e);
        }

        public void DispatchOnRecipeUpdated(object sender, EventArgs e)
        {
            Instance.OnRecipeUpdated?.Invoke(sender, e);
        }

        #endregion


    }
}
