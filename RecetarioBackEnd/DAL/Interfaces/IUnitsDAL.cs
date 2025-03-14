using RecetarioBackEnd.Models;

namespace RecetarioBackEnd.DAL.Interfaces
{
    public interface IUnitsDAL
    {
        void CreateUnit(Unit unit);
        IEnumerable<Unit> GetAllUnits();
        Unit? GetUnit(int id);
        Unit? GetUnit(string abbreviation);
        void UpdateUnit(Unit unit);
    }
}