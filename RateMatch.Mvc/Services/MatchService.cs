using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using RateMatch.Mvc.Data;

namespace RateMatch.Mvc.Services
{
    public class MatchService : IDataService<SportsMatch>
    {
        private readonly ApplicationDbContext _context;

        public MatchService(ApplicationDbContext context)
        {
            _context = context;
        }

        private IQueryable<SportsMatch> GetAllBase()
        {
            return _context.SportsMatches
                .Include(x => x.Reviews).ThenInclude(x => x.User)
                .Include(x => x.Competition).ThenInclude(x => x.Sport);
        }
        private IQueryable<SportsMatch> SingleBase(int id)
        {
            return _context.SportsMatches
                .Include(x => x.Reviews).ThenInclude(x => x.User)
                .Include(x => x.Competition).ThenInclude(x => x.Sport)
                .Where(x=>x.Id==id);
        }

        public async Task<List<SportsMatch>> GetAllAsync()
        {
            return await this.GetAllBase().OrderByDescending(x => x.PlayedAt).ToListAsync();
        }

        public async Task<List<SportsMatch>> GetAllAsync(int limit)
        {
            return await this.GetAllBase().OrderByDescending(x=>x.PlayedAt).Take(limit).ToListAsync();
        }

        public async Task<SportsMatch?> SingleAsync(int id)
        {
            return await this.SingleBase(id).FirstOrDefaultAsync();
        }
    }
}
