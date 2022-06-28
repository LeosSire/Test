using System.Collections.Generic;
using TestNew.Models;

namespace TestNew.Services.Interfaces
{
    /// <summary>
    /// Loan Service Interface
    /// </summary>
    public interface ILoanService
    {
        /// <summary>
        /// Claims the successful.
        /// </summary>
        /// <param name="claim">The claim.</param>
        /// <returns></returns>
        Criteria ClaimSuccessful(Claim claim);

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
