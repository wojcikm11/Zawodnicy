using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zawodnicy.core.Domain;
using Zawodnicy.Core.Repositories;

namespace Zawodnicy.Infrastructure.Repositories
{
    public class SkiJumperRepository : ISkiJumperRepository
    {
        private AppDbContext _appDbContext;

        public SkiJumperRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(SkiJumper s)
        {
            try
            {
                _appDbContext.SkiJumper.Add(s);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<SkiJumper>> BrowseAllAsync()
        {
            return await Task.FromResult(_appDbContext.SkiJumper);
        }

        public async Task<IEnumerable<SkiJumper>> BrowseAllByFilterAsync(string country, string name)
        {
            return await Task.FromResult(_appDbContext.SkiJumper.Where(x => x.Country.Contains(country) || x.Name.Contains(name)));
        }

        public async Task<IEnumerable<SkiJumper>> BrowseAllByFilterAsync(string country)
        {
            return await Task.FromResult(_appDbContext.SkiJumper.Where(x => x.Country.Contains(country)));
        }

        public async Task DelAsync(SkiJumper s)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.SkiJumper.FirstOrDefault(x => x.Id == s.Id));
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                await Task.FromException(ex);
            }
            
        }

        public async Task<SkiJumper> GetAsync(int id)
        {
            return await Task.FromResult(_appDbContext.SkiJumper.FirstOrDefault(s => s.Id == id));
        }

        public async Task UpdateAsync(SkiJumper s)
        {
            try
            {
                var z = _appDbContext.SkiJumper.FirstOrDefault(x => x.Id == s.Id);

                z.Name = s.Name;
                z.ForeName = s.ForeName;
                z.BirthDate = s.BirthDate;
                z.Weight = s.Weight;
                z.Country = s.Country;
                z.Height = s.Height;
                z.Weight = s.Weight;

                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }
    }
}
