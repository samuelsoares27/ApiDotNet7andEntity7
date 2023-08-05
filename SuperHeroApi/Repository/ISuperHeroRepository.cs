namespace SuperHeroApi.Repository
{
    public interface ISuperHeroRepository
    {
        Task<List<SuperHero>> GetAllSuperHeroes();
        Task<SuperHero?> GetSingleHero(int id);
        Task<SuperHero?> AddHero(SuperHero Hero);
        Task<SuperHero?> UpdateHero(SuperHero Hero);
        Task<SuperHero?> DeleteHero(int id);
    }
}
