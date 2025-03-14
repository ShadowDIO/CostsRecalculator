using RecetarioBackEnd.DTO;
using RecetarioBackEnd.Models;

namespace RecetarioBackEnd.BLL.Interfaces
{
    public interface IUnitsBLL
    {
        IEnumerable<UnitDTO> GetAllUnits();
        UnitDTO? GetUnit(int id);
        UnitDTO? GetUnit(string abbreviation);
        void CreateUnit(UnitDTO unitDTO);
        void UpdateUnit(UnitDTO unitDTO);
    }
}
