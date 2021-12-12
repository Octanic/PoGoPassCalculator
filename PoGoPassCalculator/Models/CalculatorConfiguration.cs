using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoGoPassCalculator.Models
{
    public class CalculatorConfiguration
    {
        /// <summary>
        /// Bundles you want to compare
        /// </summary>
        public IList<Bundle> BundlesToCompare
        {
            get { return _bundles; }
            set { _bundles = value; notifyStateChanged(); }
        }
        private IList<Bundle> _bundles;


        /// <summary>
        /// money spent
        /// </summary>
        public decimal InvestedValue
        {
            get { return _investedValue; }
            set { _investedValue = value; notifyStateChanged(); }
        }
        private decimal _investedValue;


        /// <summary>
        /// How much coins user has
        /// </summary>
        public decimal CoinsProduced
        {
            get { return _coinsProduced; }
            set { _coinsProduced = value; notifyStateChanged(); }
        }
        private decimal _coinsProduced;


        /// <summary>
        /// How much money is left 
        /// </summary>
        public decimal SpareMoney { get; private set; }
        public void SetSpareMoney(decimal value)
        {
            SpareMoney = value;
            notifyStateChanged();
        }

        /// <summary>
        /// How much it costs for the unit bundle you are trying to buy
        /// </summary>
        /// <remarks>
        /// In Brazil, the best value is the R$ 1.90 bundle. The others are pointless to buy, because they are too expensive for its return. 
        /// I.e. the first bundle is 1.90 holding 100 coins; the second one is 18.90 and holds 500 coins.
        /// </remarks>        
        public decimal Meta_UnitCost
        {
            get { return _metaUnitCost; }
            set { _metaUnitCost = value; notifyStateChanged(); }
        }
        private decimal _metaUnitCost = 1.9m;


        /// <summary>
        /// How many coins are produced by buying one <code>Meta_UnitCost</code>
        /// </summary>
        public decimal Meta_CoinsReceivedByUnit
        {
            get { return _meta_CoinsReceivedByUnit; }
            set { _meta_CoinsReceivedByUnit = value; notifyStateChanged(); }
        }
        private decimal _meta_CoinsReceivedByUnit = 100m;


        /// <summary>
        /// Actual currency
        /// </summary>
        /// <remarks>
        /// Mostly for reading purposes.
        /// </remarks>
        public string Meta_Currency
        {
            get
            {
                return _metaCurrency;
            }
            set
            {
                _metaCurrency = value;
                notifyStateChanged();
            }
        }
        private string _metaCurrency = "R$";

        public event Action OnChange;

        private void notifyStateChanged() => OnChange?.Invoke();
    }

}
