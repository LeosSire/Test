using System.Collections.Generic;
using TestNew.interfaces;
using TestNew.Models;
using TestNew.Repos.Interfaces;
using TestNew.Services.Interfaces;

namespace TestNew.Services
{

    /// <summary>
    /// Loan Service
    /// </summary>
    /// <seealso cref="TestNew.Services.Interfaces.ILoanService" />
    /// <seealso cref="TestNew.ILoanService" />
    class LoanService : ILoanService
    {
        /// <summary>
        /// The criteria repo
        /// </summary>
        ICriteriaRepo criteriaRepo;

        /// <summary>
        /// The claim repo
        /// </summary>
        IClaimRepo claimRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoanService" /> class.
        /// </summary>
        /// <param name="criteriaRepo">The criteria repo.</param>
        /// <param name="claimRepo">The claim repo.</param>
        public LoanService(ICriteriaRepo criteriaRepo, IClaimRepo claimRepo)
        {
            this.criteriaRepo = criteriaRepo;
            this.claimRepo = claimRepo;
        }

        /// <summary>
        /// Adds the claim.
        /// </summary>
        /// <param name="claim">The claim.</param>
        public void AddClaim(Claim claim)
        {
            this.claimRepo.AddClaim(claim);
        }

        /// <summary>
        /// Claims the successful.
        /// </summary>
        /// <param name="claim">The claim.</param>
        /// <returns></returns>
        public Criteria ClaimSuccessful(Claim claim)
        {
            foreach (var cri in criteriaRepo.GetCriteria())
            {
                if (cri.ClaimSuccessful(claim))
                {
                    return cri;
                }
            }
            return null;
        }

        /// <summary>
        /// Gets the claims.
        /// </summary>
        /// <returns></returns>
        public List<Claim> GetClaims()
        {
            return this.claimRepo.GetClaims();
        }
    }
}
