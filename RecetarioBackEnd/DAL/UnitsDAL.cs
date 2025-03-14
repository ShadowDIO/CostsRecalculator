using Microsoft.EntityFrameworkCore;
using RecetarioBackEnd.DAL.Interfaces;
using RecetarioBackEnd.Models;

namespace RecetarioBackEnd.DAL
{
    public class UnitsDAL : DALBase, IUnitsDAL
    {
        public UnitsDAL()
        {
            db = new RecetarioDbContext();
        }

        public UnitsDAL(DbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Unit> GetAllUnits()
        {
            return ((RecetarioDbContext)db).Units;
        }

        public Unit? GetUnit(int id)
        {
            return ((RecetarioDbContext)db).Units.FirstOrDefault(p => p.Id == id);
        }

        public Unit? GetUnit(string abbreviation)
        {
            return ((RecetarioDbContext)db).Units.FirstOrDefault(p => p.Abbreviation.ToLower() == abbreviation.ToLower());
        }

        public void CreateUnit(Unit unit)
        {
            ((RecetarioDbContext)db).Add<Unit>(unit);

            ((RecetarioDbContext)db).SaveChanges();
        }

        public void UpdateUnit(Unit unit)
        {
            ((RecetarioDbContext)db).Update(unit);

            ((RecetarioDbContext)db).SaveChanges();
        }
    }
}
