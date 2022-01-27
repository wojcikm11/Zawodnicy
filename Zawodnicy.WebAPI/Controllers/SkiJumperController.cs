using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zawodnicy.core.Domain;
using Zawodnicy.Infrastructure.Commands;
using Zawodnicy.Infrastructure.DTO;
using Zawodnicy.Infrastructure.Services;

namespace Zawodnicy.WebAPI.Controllers
{
    [Route("[Controller]")]
    public class SkiJumperController : Controller
    {
        private readonly ISkiJumperService _skiJumperService;

        public SkiJumperController(ISkiJumperService skiJumperService)
        {
            _skiJumperService = skiJumperService;
        }

        // SkiJumper
        [HttpGet]
        public async Task<IActionResult> BrowseAll()
        {
            var z = await _skiJumperService.BrowseAll();
            return Json(z);
        }

        // localhost/skijumper/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSkiJumper(int id)
        {
            var SkiJumper = await _skiJumperService.GetAsync(id);
            return Json(SkiJumper);
        }

        //skijumper/filter?country=pol&name=jan
        [HttpGet("filter")]
        public async Task<IActionResult> BrowseSkiJumpers(string country, string name = null)
        {
            IEnumerable<SkiJumperDTO> z;

            if (name == null)
            {
                z = await _skiJumperService.BrowseAllByFilterAsync(country);
            }
            else
            {
                z = await _skiJumperService.BrowseAllByFilterAsync(country, name);
            }

            return Json(z);
        }

        // skijumper
        [HttpPost]
        public async Task<IActionResult> AddSkiJumper([FromBody] CreateSkiJumper skiJumper)
        {
            await _skiJumperService.AddAsync(skiJumper);
            return Created("", skiJumper);
        }

        // skijumper/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> EditSkyJumper([FromBody] UpdateSkiJumper skiJumper, int id)
        {
            await _skiJumperService.UpdateAsync(id, skiJumper);
            return NoContent();
        }

        // skijumper/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkiJumper(int id)
        {
            await _skiJumperService.DelAsync(id);
            return NoContent();
        }
    }
}
