using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;
using Zawodnicy.Core.Repositories;

namespace Zawodnicy.Infrastructure.Repositories
{
    public class TownRepository : ITownRepository
    {
        public Task AddAsync(Town s)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Town>> BrowseAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DelAsync(Town s)
        {
            throw new NotImplementedException();
        }

        public Task<Town> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Town s)
        {
            throw new NotImplementedException();
        }
    }
}
