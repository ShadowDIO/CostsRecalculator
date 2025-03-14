namespace RecetarioBackEnd.DTO
{
    public class RecipeDTO
    {
        public long Id { get; set; }

        public string RecipeName { get; set; } = null!;

        public float Efficiency { get; set; }

        public float AmountProduced { get; set; }

        public int UnitId { get; set; }

        public string UnitName { get; set; } = string.Empty;

        public double Cost { get; set; }

        public IEnumerable<RecipeIngredientDTO> Ingredients { get; set; } = new List<RecipeIngredientDTO>();

        public IEnumerable<RecipeSubRecipeDTO> SubRecipes { get; set; } = new List<RecipeSubRecipeDTO>();
    }
}
