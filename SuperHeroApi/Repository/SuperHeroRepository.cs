using Microsoft.EntityFrameworkCore;
using SuperHeroApi.Data;

namespace SuperHeroApi.Repository
{
    public class SuperHeroRepository : ISuperHeroRepository
    {
        private static List<SuperHero> _superHeroes = new();
        private readonly DataContext _context;

        public SuperHeroRepository(DataContext context)
        {
            _context = context;
        }
        //private readonly _superHeroes.Add(new SuperHero
        //    {
        //        Id = 1,
        //        Name = "Homem aranha",
        //        FirstName = "Peter",
        //        LastName = "Parker",
        //        Place = "Nova York"
        //    });
        //    _superHeroes.Add(new SuperHero
        //    {
        //        Id = 2,
        //        Name = "Homem de Ferro",
        //        FirstName = "Tony",
        //        LastName = "Stark",
        //        Place = "Malibu"
        //    });
        public async Task<SuperHero?> AddHero(SuperHero Hero)
        {
            await _context.SuperHeroes.AddAsync(Hero);
            await _context.SaveChangesAsync();
            return Hero;
        }

        public async Task<SuperHero?> DeleteHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);

            if(hero is not null) {
                _context.SuperHeroes.Remove(hero);
                await _context.SaveChangesAsync();
            }
            
            return hero;
        }

        public async Task<List<SuperHero>> GetAllSuperHeroes()
        {
            var heroes = await _context.SuperHeroes.ToListAsync();
            return heroes;
        }

        public async Task<SuperHero?> GetSingleHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            return hero;
        }

        public async Task<SuperHero?> UpdateHero(SuperHero Hero)
        {
            var heroExist = await _context.SuperHeroes.FindAsync(Hero.Id);

            if (heroExist is not null)
            {
                _context.SuperHeroes.Remove(Hero);
                await _context.SaveChangesAsync();
            }
            
            return Hero;
        }
    }
}
