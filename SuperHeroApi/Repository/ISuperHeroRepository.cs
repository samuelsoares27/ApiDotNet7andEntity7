namespace SuperHeroApi.Repository
{
    public interface ISuperHeroRepository : IRepository<SuperHero>, IDisposable
    {
        List<SuperHero>? GetSuperHeroesAndPlace();
    }
}
