using System.Linq;
using TestNew.Models;

namespace TestNew.Repos.Interfaces
{
    /// <summary>
    /// Criteria Repo Interface
    /// </summary>
    public interface ICriteriaRepo
    {
        /// <summary>
        /// Gets the criteria.
        /// </summary>
        /// <returns></returns>
        IQueryable<Criteria> GetCriteria();
    }
}
