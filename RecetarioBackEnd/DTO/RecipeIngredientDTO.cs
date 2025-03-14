namespace RecetarioBackEnd.DTO
{
    public class RecipeIngredientDTO
    {
        public int Id { get; set; }
        public long IngredientId { get; set; }

        public long RecipeId { get; set; }

        public IngredientDTO Ingredient { get; set; } = null!;

        public RecipeDTO? Recipe { get; set; } = null!;

        public double Quantity { get; set; }

        public double Efficiency { get; set; } = 1f;

        public double Cost { get; set; }
    }
}
