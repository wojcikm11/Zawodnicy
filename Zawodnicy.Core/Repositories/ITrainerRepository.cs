using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;

namespace Zawodnicy.Core.Repositories
{
    public interface ITrainerRepository
    {
        Task<IEnumerable<Trainer>> BrowseAllAsync();
        Task<IEnumerable<Trainer>> BrowseAllByFilterAsync(string lastName);
        Task<Trainer> GetAsync(int id);
        Task DelAsync(Trainer s);
        Task UpdateAsync(Trainer s);
        Task AddAsync(Trainer s);
    }
}
