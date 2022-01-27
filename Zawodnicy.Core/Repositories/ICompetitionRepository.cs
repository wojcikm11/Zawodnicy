using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zawodnicy.Core.Domain;

namespace Zawodnicy.Core.Repositories
{
    public interface ICompetitionRepository
    {
        Task<IEnumerable<Competition>> BrowseAllAsync();
        Task<Competition> GetAsync(int id);
        Task DelAsync(Competition s);
        Task UpdateAsync(Competition s);
        Task AddAsync(Competition s);
    }
}
