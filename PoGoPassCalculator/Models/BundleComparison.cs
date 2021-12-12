using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoGoPassCalculator.Models
{
    public class BundleComparison
    {
        public Bundle BundleA { get; set; }
        public Bundle BundleB { get; set; }
        public decimal PassDifference
        {
            get
            {
                if (BundleA == null || BundleB == null) return 0;
                return Math.Abs(BundleA.ReceivedPasses - BundleB.ReceivedPasses);
            }
        }
        public int? BestBundleId { get; set; }
    }
}
