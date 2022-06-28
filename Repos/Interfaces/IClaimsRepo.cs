using System.Collections.Generic;
using TestNew.Models;

namespace TestNew.interfaces
{
    /// <summary>
    /// Claim Repo Interface
    /// </summary>
    public interface IClaimRepo
    {
        /// <summary>
        /// Gets the claims.
        /// </summary>
        /// <returns></returns>
        List<Claim> GetClaims();

        /// <summary>
        /// Adds the claim.
        /// </summary>
        /// <param name="claim">The claim.</param>
        void AddClaim(Claim claim);
    }
}
