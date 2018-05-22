using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL_ZVV.Interfaces;
using DAL_ZVV.Entities;
using System.Data.Entity;

namespace DAL_ZVV.Repositories
{
    public class EFLabGWRepository : IRepository<LabGlassware>
    {
        private ApplicationDbContext context;
        private DbSet<LabGlassware> table;

        public EFLabGWRepository(ApplicationDbContext ctx)
        {
            context = ctx;
            table = context.LabGlasswares;
        }

        public void Create(LabGlassware t)
        {
            table.Add(t);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Entry(new LabGlassware { GW_ID = id })
                .State = EntityState.Deleted;
            context.SaveChanges();
        }

        public IEnumerable<LabGlassware> Find(Func<LabGlassware, bool> predicate)
        {
            return table.Where(predicate).ToList();
        }

        public LabGlassware Get(int id)
        {
            return table.Find(id);
        }

        public IEnumerable<LabGlassware> GetAll()
        {
            return table;
        }

        public async Task<LabGlassware> GetAsync(int id)
        {
            return await table.FindAsync(id);
        }

        public void Update(LabGlassware t)
        {
            if (t.GW_Picture == null)
            {
                var lgw = context.LabGlasswares
                    .AsNoTracking()
                    .Where(d => d.GW_ID == t.GW_ID)
                    .FirstOrDefault();
                t.GW_Picture = lgw.GW_Picture;
                t.GW_MIMEType = lgw.GW_MIMEType;
            }
            context.Entry(t).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}