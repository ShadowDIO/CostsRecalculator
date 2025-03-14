using RecetarioBackEnd.Enums;

namespace RecetarioBackEnd.DTO
{
    public class RecipeRecalculateParametersDTO
    {
        public RecalculateTypeEnum RecalculateType { get; set; } = RecalculateTypeEnum.Cost;

        public RecalculateOverFieldEnum RecalculateOverField { get; set; } = RecalculateOverFieldEnum.Total;

        public int RecalculateFieldId { get; set; } = -1;

        public double RecalculateValue { get; set; } = 1d;
    }
}
