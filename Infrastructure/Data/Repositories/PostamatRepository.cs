using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    /// <summary>
    /// Postamat repository implementation 
    /// </summary>
    public class PostamatRepository : EFRepository<Postamat>, IReadRepository<Postamat>, IRepository<Postamat>, IPostamatRepository
    {
        /// <summary>
        /// ctor
        /// </summary>
        public PostamatRepository(MainContext dbContext) : base(dbContext)
        { }

        /// <inheritdoc />
        public async Task<Postamat> GetByNumberAsync(string number) => await _dbMainContext.Postamates.FirstOrDefaultAsync(postamat => postamat.Number == number);

        /// <inheritdoc />
        public async Task<IEnumerable<Postamat>> GetWorkingAsync() => await _dbMainContext.Postamates.Where(postamat => postamat.Status).OrderBy(postamat => postamat.Number).ToListAsync();
    }
}