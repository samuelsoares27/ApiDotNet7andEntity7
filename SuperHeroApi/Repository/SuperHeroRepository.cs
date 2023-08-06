using Microsoft.EntityFrameworkCore;
using SuperHeroApi.Data;

namespace SuperHeroApi.Repository
{
    public class SuperHeroRepository : Repository<SuperHero>, ISuperHeroRepository
    {
        private readonly DataContext _context;

        public SuperHeroRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public List<SuperHero>? GetSuperHeroesAndPlace()
        { 
            var query = from s in _context.SuperHeroes
            join p in _context.Places on s.IdPlace equals p.Id
            select new SuperHero
            {
                Id = s.Id,
                Name = s.Name,
                FirstName = s.FirstName,
                LastName = s.LastName,
                IdPlace = s.IdPlace,
                Place = new Place
                {
                    Id = p.Id,
                    City = p.City,
                    Country = p.Country,
                }
            };

            return query.ToList();
        }
    }
}
