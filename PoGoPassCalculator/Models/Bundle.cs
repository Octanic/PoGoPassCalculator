using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoGoPassCalculator.Models
{
    public class Bundle
    {
        public int BundleId { get; set; }

        /// <summary>
        /// Defines the type of raid pass bundles
        /// </summary>
        public enum BundlePassType
        {
            Remoto,
            Premium
        }

        /// <summary>
        /// Type of the pass we have in this bundle
        /// </summary>
        public BundlePassType PassType { get; set; }

        /// <summary>
        /// Quantity of raid passes received in this bundle
        /// </summary>
        public int PassQuantity { get; set; }

        /// <summary>
        /// How many coins it costs to purchase the bundle.
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// Remaining Coins after calculations
        /// </summary>
        public decimal RemainingCoins { get; private set; }
        public void SetRemainingCoins(decimal value)
        {
            RemainingCoins = value;
        }

        public decimal ReceivedPasses { get; private set; }
        public void SetReceivedPasses(decimal value)
        {
            ReceivedPasses = value;
        }

    }
}
