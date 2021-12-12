using PoGoPassCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoGoPassCalculator.Services
{
    public class CalculatorService
    {
        public AnalysisResult CalculateBundles(CalculatorConfiguration config)
        {
            AnalysisResult result = new AnalysisResult();
            int id = 1;

            if (config.CoinsProduced == 0 && config.InvestedValue == 0)
            {
                throw new ArgumentException("Invalid Values");
            }

            //Check if the Coins produced was calculated
            if (config.InvestedValue > 0)
            {
                config.CoinsProduced = Math.Floor(config.InvestedValue / config.Meta_UnitCost) * config.Meta_CoinsReceivedByUnit;
            }

            //Get the spare money left
            config.SetSpareMoney(config.InvestedValue % config.Meta_UnitCost);

            //Set comparing values through bundles
            foreach (var bundle in config.BundlesToCompare)
            {
                bundle.BundleId = id++;
                bundle.SetRemainingCoins(config.CoinsProduced % bundle.Value);
                bundle.SetReceivedPasses(Math.Floor(config.CoinsProduced / bundle.Value) * bundle.PassQuantity);

                if (bundle.ReceivedPasses > (result.BestBundle?.ReceivedPasses ?? 0))
                {
                    result.BestBundle = bundle;
                }
            }
            
            result.Configuration = config;

            //Get comparison results
            result.PassQuantityComparison = getBundleComparison(result);

            return result;
        }

        private IEnumerable<BundleComparison> getBundleComparison(AnalysisResult result)
        {
            List<BundleComparison> comparisons = new List<BundleComparison>();

            Bundle[] bundles = result.Configuration.BundlesToCompare.ToArray();

            if (bundles.Length <= 1) throw new InvalidOperationException("Cannot compare less than 2 bundles");

            for (int i = 0; i < bundles.Count()-1; i++)
            {
                for (int j = 1; j < bundles.Count(); j++)
                {
                    BundleComparison comparison = new BundleComparison()
                    {
                        BundleA = bundles[i],
                        BundleB = bundles[j],
                    };

                    if (bundles[i].ReceivedPasses > bundles[j].ReceivedPasses)
                    {
                        comparison.BestBundleId = bundles[i].BundleId;
                    }
                    else if(bundles[i].ReceivedPasses < bundles[j].ReceivedPasses)
                    {
                        comparison.BestBundleId = bundles[j].BundleId;
                    }
                    else
                    {
                        comparison.BestBundleId = -1;
                    }

                    comparisons.Add(comparison);
                }
            }

            return comparisons;
        }
    }
}
