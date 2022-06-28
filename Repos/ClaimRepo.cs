using System.Collections.Generic;
using TestNew.interfaces;
using TestNew.Models;

namespace TestNew.Repos
{
    /// <summary>
    /// Claims Repo
    /// </summary>
    /// <seealso cref="TestNew.interfaces.IClaimRepo" />
    /// <seealso cref="TestNew.IClaimRepo" />
    public class ClaimRepo : IClaimRepo
    {
        /// <summary>
        /// The claims
        /// </summary>
        List<Claim> claims;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClaimRepo" /> class.
        /// </summary>
        public ClaimRepo()
        {
            claims = new List<Claim>
            {
                new Claim(1000001, 1500000, 975, true),
                new Claim(10000000, 15000000, 999, false),
                new Claim(1000, 150000, 999, false),
                new Claim(123123, 421321, 975, true),
                new Claim(1231231, 1500000, 600, true),
                new Claim(100010, 123454, 321, false),
            };
        }

        /// <summary>
        /// Adds the claim.
        /// </summary>
        /// <param name="claim">The claim.</param>
        public void AddClaim(Claim claim)
        {
            this.claims.Add(claim);
        }

        /// <summary>
        /// Gets the claims.
        /// </summary>
        /// <returns></returns>
        public List<Claim> GetClaims()
        {
            return claims;
        }
    }
}
