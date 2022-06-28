using System.Collections.Generic;
using System.Linq;
using TestNew.Models;
using TestNew.Repos.Interfaces;

namespace TestNew.Repos
{
    /// <summary>
    /// Criteria Repo
    /// </summary>
    /// <seealso cref="TestNew.Repos.Interfaces.ICriteriaRepo" />
    /// <seealso cref="TestNew.ICriteriaRepo" />
    public class CriteriaRepo : ICriteriaRepo
    {
        /// <summary>
        /// Gets the criteria.
        /// </summary>
        /// <returns></returns>
        public IQueryable<Criteria> GetCriteria()
        {
            return new List<Criteria>
            {
                new Criteria(GreaterLower.Greater, 1500000, null, null),
                new Criteria(GreaterLower.Lower, 100000, null, null),
                new Criteria(GreaterLower.Greater, 1000000, 60, 950),
                new Criteria(GreaterLower.Lower, 1000000, 60, 750),
                new Criteria(GreaterLower.Lower, 1000000, 80, 800),
                new Criteria(GreaterLower.Lower, 1000000, 90, 900),
            }.AsQueryable();
        }
    }
}
