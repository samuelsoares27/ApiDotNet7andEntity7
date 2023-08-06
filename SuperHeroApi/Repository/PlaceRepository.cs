using SuperHeroApi.Data;

namespace SuperHeroApi.Repository
{
    public class PlaceRepository : Repository<Place>, IPlaceRepository
    {
        private readonly DataContext _context;

        public PlaceRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
