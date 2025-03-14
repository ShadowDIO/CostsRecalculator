namespace RecetarioBackEnd.DTO
{
    public class RecipeSubRecipeDTO
    {
        public int Id { get; set; }
        public long RecipeId { get; set; }

        public long SubRecipeId { get; set; }

        public RecipeDTO? SubRecipe { get; set; } = null!;

        public double Quantity { get; set; }

        public double Efficiency { get; set; } = 1f;

        public double Cost { get; set; }
    }
}
