using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces.Repositories
{
    /// <summary>
    /// Postamat repository interface
    /// </summary>
    public interface IPostamatRepository
    {
        /// <summary>
        /// Find a postamat by its number
        /// </summary>
        /// <param name="number">Postamat number</param>
        /// <returns>Current postamat</returns>
        Task<Postamat> GetByNumberAsync(string number);

        /// <summary>
        /// Get all working postamates sorted alphabetically 
        /// </summary>
        /// <returns>List of postamates</returns>
        Task<IEnumerable<Postamat>> GetWorkingAsync();
    }
}