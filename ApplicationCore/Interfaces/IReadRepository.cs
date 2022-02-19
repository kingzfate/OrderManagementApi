using Ardalis.Specification;

namespace ApplicationCore.Interfaces
{
    /// <summary>
    /// Read repository
    /// </summary>
    /// <typeparam name="T">Unique param</typeparam>
    public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class
    {
    }
}