using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zawodnicy.core.Domain;
using Zawodnicy.Core.Domain;

namespace Zawodnicy.Core.Repositories
{
    public interface ITownRepository
    {
        Task<IEnumerable<Town>> BrowseAllAsync();
        Task<Town> GetAsync(int id);
        Task DelAsync(Town s);
        Task UpdateAsync(Town s);
        Task AddAsync(Town s);
    }
}