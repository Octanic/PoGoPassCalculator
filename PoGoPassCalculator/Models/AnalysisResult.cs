using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoGoPassCalculator.Models
{
    public class AnalysisResult
    {
        /// <summary>
        /// Configuration to generate the results
        /// </summary>
        public CalculatorConfiguration Configuration { get; set; }

        /// <summary>
        /// Best bundle to buy
        /// </summary>
        public Bundle BestBundle { get; set; }

        /// <summary>
        /// How many passes you'll get more compared to the others
        /// </summary>
        public IEnumerable<BundleComparison> PassQuantityComparison { get; set; }

        
    }
}
