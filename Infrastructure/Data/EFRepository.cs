using ApplicationCore.Interfaces;
using Ardalis.Specification.EntityFrameworkCore;

namespace Infrastructure.Data
{
    /// <summary>
    /// Main EF repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EFRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class
    {
        protected readonly MainContext _dbMainContext;

        /// <summary>
        /// ctor
        /// </summary>
        public EFRepository(MainContext dbContext) : base(dbContext)
        { 
            _dbMainContext = dbContext; 
        } 
    }
}