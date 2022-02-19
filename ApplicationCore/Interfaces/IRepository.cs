using Ardalis.Specification;

namespace ApplicationCore.Interfaces
{
    /// <summary>
    /// Default repository
    /// </summary>
    /// <typeparam name="T">Unique param</typeparam>
    public interface IRepository<T> : IRepositoryBase<T> where T : class
    {
    }
}