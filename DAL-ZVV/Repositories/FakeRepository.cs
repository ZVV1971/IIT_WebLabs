using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL_ZVV.Interfaces;
using DAL_ZVV.Entities;

namespace DAL_ZVV.Repositories
{
    public class FakeRepository : IRepository<LabGlassware>
    {
        public IEnumerable<LabGlassware> GetAll()
        {
            return new List<LabGlassware>
            {
            new LabGlassware {GW_ID=1, GW_Name="Колба стеклянная коническая 500 мл",
                            GW_Description="Обычная колба", GW_Type = "Колба", GW_Price = 35},
            new LabGlassware {GW_ID=2, GW_Name="Колба стеклянная круглодонная 1000 мл",
                            GW_Description="Для работ при пониженном давлении", GW_Type = "Колба", GW_Price = 55},
            new LabGlassware {GW_ID=3, GW_Name="Бюкс 25 x 25",
                            GW_Description="Для взвешивания", GW_Type = "Бюкс", GW_Price = 15},
            new LabGlassware {GW_ID=4, GW_Name="Бюкс 30 x 35",
                            GW_Description="Для взвешивания", GW_Type = "Бюкс", GW_Price = 19},
            new LabGlassware {GW_ID=5, GW_Name="Бюретка 50мл",
                            GW_Description="Цена деления 0,1 мл", GW_Type = "Бюретка", GW_Price = 22},
            new LabGlassware {GW_ID=6, GW_Name="Бюретка 20мл",
                            GW_Description="Цена деления 0,05 мл", GW_Type = "Бюретка", GW_Price = 33},
            new LabGlassware {GW_ID=7, GW_Name="Test GW",
                            GW_Description="No description", GW_Type = "Test", GW_Price = 0}
            };
        }

        public LabGlassware Get(int id)
        {
            return new LabGlassware();
        }

        public async Task<LabGlassware> GetAsync(int id)
        {
            return null;
        }

        public IEnumerable<LabGlassware> Find(Func<LabGlassware, bool> predicate)
        {
            yield return new LabGlassware();
        }

        public void Create(LabGlassware t)
        {

        }

        public void Update(LabGlassware t)
        {

        }

        public void Delete(int id)
        {

        }
    }
}