namespace RecetarioBackEnd.DTO
{
    public class IngredientDTO
    {
        public long Id { get; set; }

        public string IngredientName { get; set; } = string.Empty;

        public double AmountSoldBy { get; set; }

        public double Cost { get; set; }

        public long UnitId { get; set; }

        public string UnitName { get; set; } = string.Empty;

        public double Efficiency { get; set; }

        public string? Provider { get; set; }
        public string Abbreviation { get; set; } = string.Empty;
    }
}
