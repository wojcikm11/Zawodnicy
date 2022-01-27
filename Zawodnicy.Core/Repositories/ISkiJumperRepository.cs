using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zawodnicy.core.Domain;

namespace Zawodnicy.Core.Repositories
{
    public interface ISkiJumperRepository
    {
        Task<IEnumerable<SkiJumper>> BrowseAllAsync();
        Task<IEnumerable<SkiJumper>> BrowseAllByFilterAsync(string country, string name);
        Task<IEnumerable<SkiJumper>> BrowseAllByFilterAsync(string country);
        Task<SkiJumper> GetAsync(int id);
        Task DelAsync(SkiJumper s);
        Task UpdateAsync(SkiJumper s);
        Task AddAsync(SkiJumper s);
    }
}
