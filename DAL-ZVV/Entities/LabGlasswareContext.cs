using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace DAL_ZVV.Entities
{
    public partial class ApplicationDbContext
    {
        public DbSet<LabGlassware> LabGlasswares { get; set; }

        public void Populate()
        {
            if (!LabGlasswares.Any())
            {
                List<LabGlassware> gw = new List<LabGlassware>
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
                LabGlasswares.AddRange(gw);
                SaveChanges();
            }
        }
    }
}