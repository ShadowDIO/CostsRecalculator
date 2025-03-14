namespace RecetarioBackEnd.DTO
{
    public class UnitDTO
    {
        public long Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Abbreviation { get; set; } = string.Empty;

        public IEnumerable<IngredientDTO> Ingredients { get; set; } = new List<IngredientDTO>();

        public IEnumerable<RecipeDTO> Recipes { get; set; } = new List<RecipeDTO>();
    }
}

