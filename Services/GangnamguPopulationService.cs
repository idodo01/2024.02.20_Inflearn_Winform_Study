using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsAppMaster.Interfaces;
using WinFormsAppMaster.Models;

namespace WinFormsAppMaster.Services
{
    internal class GangnamguPopulationService : IDatabase<GangnamguPopulation>
    {
        private readonly WinformDbContext? _winformDbContext;

        public GangnamguPopulationService(WinformDbContext winformDbContext)
        {
            _winformDbContext = winformDbContext;
        }

        public void Create(GangnamguPopulation entity)
        {
            this._winformDbContext?.GangnamguPopulations.Add(entity);
            this._winformDbContext?.SaveChanges();
        }

        public void Delete(int? id)
        {
            var validData = this._winformDbContext?.GangnamguPopulations.FirstOrDefault(x => x.Id == id);

            if (validData != null)
            {
                this._winformDbContext?.GangnamguPopulations.Remove(validData);
                this._winformDbContext?.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public List<GangnamguPopulation>? Get()
        {
            return this._winformDbContext?.GangnamguPopulations.ToList();
        }

        public GangnamguPopulation GetDetail(int? id)
        {
            var validData = this._winformDbContext?.GangnamguPopulations.FirstOrDefault(x => x.Id == id);

            if (validData != null)
            {
                return validData;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public void Update(GangnamguPopulation entity)
        {
            this._winformDbContext?.GangnamguPopulations.Update(entity);
            this._winformDbContext?.SaveChanges();
        }
    }
}
