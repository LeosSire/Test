using System;

namespace TestNew.Models
{
    /// <summary>
    /// Criteria Model
    /// </summary>
    public class Criteria
    {
        /// <summary>
        /// The greater lower
        /// </summary>
        GreaterLower greaterLower;

        /// <summary>
        /// The value
        /// </summary>
        int value;

        /// <summary>
        /// The LTV limit
        /// </summary>
        int? ltvLimit;

        /// <summary>
        /// The minimum credit score
        /// </summary>
        int? minCreditScore;

        /// <summary>
        /// Initializes a new instance of the <see cref="Criteria" /> class.
        /// </summary>
        /// <param name="greaterLower">The greater lower.</param>
        /// <param name="loanValue">The loan value.</param>
        /// <param name="minLtv">The minimum LTV.</param>
        /// <param name="minCreditScore">The minimum credit score.</param>
        public Criteria(GreaterLower greaterLower, int loanValue, int? minLtv, int? minCreditScore)
        {
            this.greaterLower = greaterLower;
            this.value = loanValue;
            this.ltvLimit = minLtv;
            this.minCreditScore = minCreditScore;
        }

        /// <summary>
        /// Claims the successful.
        /// Move to service with more time
        /// </summary>
        /// <param name="claim">The claim.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Claim too high
        /// or
        /// Claim too low</exception>
        public bool ClaimSuccessful(Claim claim)
        {
            if (greaterLower == GreaterLower.Greater)
            {
                if (claim.Amount > value && !HasLtvAndCreditScore())
                {
                    throw new ArgumentOutOfRangeException("Claim too high");
                }

                return CheckLtvAndCreditScore(claim) && claim.Amount > value;
            }
            else
            {
                if (claim.Amount < value && !HasLtvAndCreditScore())
                {
                    throw new ArgumentOutOfRangeException("Claim too low");
                }

                return CheckLtvAndCreditScore(claim) && claim.Amount < value;
            }
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"Claim is {greaterLower} than limit of {value} with limit of LTV {ltvLimit}% and a min. credit score of {minCreditScore}";
        }

        /// <summary>
        /// Checks the LTV and credit score.
        /// </summary>
        /// <param name="claim">The claim.</param>
        /// <returns></returns>
        private bool CheckLtvAndCreditScore(Claim claim)
        {
            return HasLtvAndCreditScore() &&
                       ValidCreditScore(claim.CreditScore) &&
                       ValidLtv(claim.Ltv);
        }

        /// <summary>
        /// Valids the credit score.
        /// </summary>
        /// <param name="creditScore">The credit score.</param>
        /// <returns></returns>
        private bool ValidCreditScore(int creditScore)
        {
            return creditScore >= this.minCreditScore;
        }

        /// <summary>
        /// Valids the LTV.
        /// </summary>
        /// <param name="ltv">The LTV.</param>
        /// <returns></returns>
        private bool ValidLtv(int ltv)
        {
            return ltv <= this.ltvLimit;
        }

        /// <summary>
        /// Determines whether [has LTV and credit score].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [has LTV and credit score]; otherwise, <c>false</c>.
        /// </returns>
        private bool HasLtvAndCreditScore()
        {
            return ltvLimit.HasValue && minCreditScore.HasValue;
        }
    }
}
