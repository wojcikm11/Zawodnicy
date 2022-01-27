using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;
using Zawodnicy.Core.Repositories;

namespace Zawodnicy.Infrastructure.Repositories
{
    public class TrainerRepository : ITrainerRepository
    {

        private AppDbContext _appDbContext;

        public TrainerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(Trainer t)
        {
            try
            {
                _appDbContext.Trainer.Add(t);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<Trainer>> BrowseAllAsync()
        {
            return await Task.FromResult(_appDbContext.Trainer);
        }

        public async Task<IEnumerable<Trainer>> BrowseAllByFilterAsync(string lastName)
        {
            return await Task.FromResult(_appDbContext.Trainer.Where(x => x.LastName.Contains(lastName)));
        }

        public async Task DelAsync(Trainer s)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.Trainer.FirstOrDefault(x => x.Id == s.Id));
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                await Task.FromException(ex);
            }
        }

        public async Task<Trainer> GetAsync(int id)
        {
            return await Task.FromResult(_appDbContext.Trainer.FirstOrDefault(s => s.Id == id));
        }

        public async Task UpdateAsync(Trainer s)
        {
            try
            {
                var z = _appDbContext.Trainer.FirstOrDefault(x => x.Id == s.Id);

                z.FirstName = s.FirstName;
                z.LastName = s.LastName;
                z.BirthDate = s.BirthDate;

                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }
    }
}
