namespace TestNew.Models
{
    /// <summary>
    /// Claims Class
    /// </summary>
    public class Claim
    {
        /// <summary>
        /// The amount
        /// </summary>
        readonly int amount;

        /// <summary>
        /// The asset value
        /// </summary>
        readonly int assetValue;

        /// <summary>
        /// The credit score
        /// </summary>
        readonly int creditScore;

        /// <summary>
        /// The approved
        /// </summary>
        bool? approved;

        /// <summary>
        /// Initializes a new instance of the <see cref="Claim" /> class.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <param name="assetValue">The asset value.</param>
        /// <param name="creditScore">The credit score.</param>
        /// <param name="approved">The approved.</param>
        public Claim(int amount, int assetValue, int creditScore, bool? approved)
        {
            this.amount = amount;
            this.assetValue = assetValue;
            this.creditScore = creditScore;
            this.approved = approved;
        }

        /// <summary>
        /// Sets the approval.
        /// </summary>
        /// <param name="approved">if set to <c>true</c> [approved].</param>
        public void SetApproval(bool approved = false)
        {
            this.approved = approved;
        }

        /// <summary>
        /// Gets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public int Amount => amount;

        /// <summary>
        /// Gets the credit score.
        /// </summary>
        /// <value>
        /// The credit score.
        /// </value>
        public int CreditScore => creditScore;

        /// <summary>
        /// Gets the asset value.
        /// </summary>
        /// <value>
        /// The asset value.
        /// </value>
        public int AssetValue => assetValue;

        /// <summary>
        /// Gets the LTV.
        /// </summary>
        /// <value>
        /// The LTV.
        /// </value>
        public int Ltv => 100 * amount / assetValue;

        /// <summary>
        /// Gets a value indicating whether this <see cref="Claim" /> is approved.
        /// </summary>
        /// <value>
        ///   <c>true</c> if approved; otherwise, <c>false</c>.
        /// </value>
        public bool Approved => approved.Value;

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"Amount: {amount}, Asset Value: {assetValue}, Credit Score {creditScore}, LTV: {Ltv}";
        }
    }

}
