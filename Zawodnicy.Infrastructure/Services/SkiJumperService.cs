using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zawodnicy.core.Domain;
using Zawodnicy.Core.Repositories;
using Zawodnicy.Infrastructure.Commands;
using Zawodnicy.Infrastructure.DTO;

namespace Zawodnicy.Infrastructure.Services
{
    public class SkiJumperService : ISkiJumperService
    {
        private readonly ISkiJumperRepository _skiJumperRepository;

        public SkiJumperService(ISkiJumperRepository skiJumperRepository)
        {
            _skiJumperRepository = skiJumperRepository;
        }

        public async Task<IEnumerable<SkiJumperDTO>> BrowseAll()
        {
            var SkiJumpers = await _skiJumperRepository.BrowseAllAsync();
            return SkiJumpers.Select(x => Map(x));
        }

        public async Task<IEnumerable<SkiJumperDTO>> BrowseAllByFilterAsync(string country, string name)
        {
            IEnumerable<SkiJumper> SkiJumpers;

            if (name == null)
            {
                SkiJumpers = await _skiJumperRepository.BrowseAllByFilterAsync(country);
            }
            else
            {
                SkiJumpers = await _skiJumperRepository.BrowseAllByFilterAsync(country, name);
            }
            
            return SkiJumpers.Select(x => Map(x));
        }

        public async Task<IEnumerable<SkiJumperDTO>> BrowseAllByFilterAsync(string country)
        {
            var SkiJumpers = await _skiJumperRepository.BrowseAllByFilterAsync(country);
            return SkiJumpers.Select(x => Map(x));
        }

        public async Task<SkiJumperDTO> GetAsync(int id)
        {
            return await Task.FromResult(Map(_skiJumperRepository.GetAsync(id).Result));
        }

        public async Task AddAsync(CreateSkiJumper s)
        {
            await _skiJumperRepository.AddAsync(Map(s));
        }

        public async Task DelAsync(int id)
        {
            var SkiJumper = _skiJumperRepository.GetAsync(id).Result;
            await _skiJumperRepository.DelAsync(SkiJumper);
        }


        public async Task UpdateAsync(int id, UpdateSkiJumper s)
        {
            await _skiJumperRepository.UpdateAsync(Map(s, id));
        }

        private SkiJumperDTO Map(SkiJumper s)
        {
            return new SkiJumperDTO()
            {
                Id = s.Id,
                Country = s.Country,
                Name = s.Name,
                BirthDate = s.BirthDate,
                ForeName = s.ForeName,
                Weight = s.Weight,
                Height = s.Height
            };
        }

        private SkiJumper Map(CreateSkiJumper s)
        {
            return new SkiJumper()
            {
                Country = s.Country,
                Name = s.Name,
                ForeName = s.ForeName
            };
        }

        private SkiJumper Map(UpdateSkiJumper s, int id)
        {
            return new SkiJumper()
            {
                Id = id,
                Country = s.Country,
                Name = s.Name,
                ForeName = s.ForeName
            };
        }
    }
}
