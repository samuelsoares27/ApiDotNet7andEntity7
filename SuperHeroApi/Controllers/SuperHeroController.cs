using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroApi.Repository;

namespace SuperHeroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {

        private static ISuperHeroRepository _superHeroRepository;
        public SuperHeroController(ISuperHeroRepository superHeroRepository)
        {
            _superHeroRepository = superHeroRepository;
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHeroes()
        {
            var superHeroes = await _superHeroRepository.GetAllSuperHeroes();
            return Ok(superHeroes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingleHero(int id)
        {
            var superHero = await _superHeroRepository.GetSingleHero(id);

            if (superHero is null)
                return NotFound("Sorry, but this hero doesn't exist");

            return Ok(superHero);
        }

        [HttpPost]
        public async Task<IActionResult> AddHero(SuperHero hero)
        {
            var superHeroes = await _superHeroRepository.GetAllSuperHeroes();
            var superHero = superHeroes.Where(super => super.Name == hero.Name);

            if (superHero is null)
                return NotFound("Sorry, but this hero exist");

            await _superHeroRepository.AddHero(hero);

            return Ok(hero);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHero(int id, SuperHero request)
        {
            var superHero = await _superHeroRepository.GetSingleHero(id);

            if (superHero is null)
                return NotFound("Sorry, but this hero doesn't exist");

            superHero.Name = request.Name;
            superHero.FirstName = request.FirstName;
            superHero.LastName = request.LastName;
            superHero.Place = request.Place;

            var hero = await _superHeroRepository.UpdateHero(superHero);

            return Ok(hero);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHero(int id)
        {
            var superHero = await _superHeroRepository.GetSingleHero(id);

            if (superHero is null)
                return NotFound("Sorry, but this hero doesn't exist");

            await _superHeroRepository.DeleteHero(superHero.Id);

            return Ok(superHero);
        }
    }
}
