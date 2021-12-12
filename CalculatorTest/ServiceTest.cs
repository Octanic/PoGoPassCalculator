using Microsoft.VisualStudio.TestTools.UnitTesting;
using PoGoPassCalculator.Models;
using PoGoPassCalculator.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculatorTest
{
    [TestClass]
    public class ServiceTest
    {
        private const int PREMIUM_PASS = 1;
        private const int REMOTE_PASS = 2;

        [TestMethod]
        public void CalculateNothing()
        {
            CalculatorService svc = new CalculatorService();

            Assert.ThrowsException<ArgumentException>(() => svc.CalculateBundles(new PoGoPassCalculator.Models.CalculatorConfiguration()));

        }

        [TestMethod]
        public void LoneBundleTest()
        {
            CalculatorConfiguration c = new CalculatorConfiguration();
            c.InvestedValue = 1000;
            c.BundlesToCompare = new List<Bundle>()
            {
                new Bundle()
                {
                     Value = 250,
                     PassType = Bundle.BundlePassType.Remoto,
                     PassQuantity = 3
                }
            };

            var svc = new CalculatorService();

            Assert.ThrowsException<InvalidOperationException>(() => svc.CalculateBundles(c));

        }

        [TestMethod]
        [DataRow(50d, 1480d, 16, 250d, 3, REMOTE_PASS, 14)]
        [DataRow(100d, 1480d, 16, 250d, 3, REMOTE_PASS, 12)]
        [DataRow(200d, 1480d, 16, 250d, 3, REMOTE_PASS, 14)]
        [DataRow(50d, 1480d, 20, 250d, 3, REMOTE_PASS, 10)]
        [DataRow(100d, 1480d, 20, 250d, 3, 0, 0)]
        [DataRow(200d, 1480d, 20, 250d, 3, PREMIUM_PASS, 14)]
        [DataRow(300d, 1480d, 20, 250d, 3, PREMIUM_PASS, 14)]
        public void TestDualComparison(double investedValue, double valueA, int qtyPassA, double valueB, int qtyPassB, int bestIdExpected, int passDifferenceExpected)
        {
            var config = getDualConfig((decimal)investedValue, (decimal)valueA, qtyPassA, (decimal)valueB, qtyPassB);

            var svc = new CalculatorService();
            var result = svc.CalculateBundles(config);

            Assert.IsTrue((result.BestBundle?.BundleId ?? 0) == bestIdExpected, $"BundleId from BestBundle is different: sent {result.BestBundle?.BundleId ?? 0}, expected {bestIdExpected}");
            Assert.IsTrue(result.PassQuantityComparison.First().BestBundleId == bestIdExpected, $"BundleId from comparison is different: sent {result.PassQuantityComparison.First().BestBundleId}, expected {bestIdExpected}");
            Assert.IsTrue(result.PassQuantityComparison.First().PassDifference == passDifferenceExpected, $"Pass difference is different: {result.PassQuantityComparison.First().PassDifference} expected {passDifferenceExpected}");

        }



        private static CalculatorConfiguration getDualConfig(decimal investedValue, decimal valueA, int qtyPassA, decimal valueB, int qtyPassB)
        {
            CalculatorConfiguration c = new CalculatorConfiguration();
            c.InvestedValue = investedValue;
            c.BundlesToCompare = new List<Bundle>()
            {
                new Bundle()
                {
                    PassQuantity = qtyPassA,
                    PassType = Bundle.BundlePassType.Premium,
                    Value = valueA
                },
                new Bundle()
                {
                     Value = valueB,
                     PassType = Bundle.BundlePassType.Remoto,
                     PassQuantity = qtyPassB
                }
            };

            return c;
        }

        //[TestMethod]
        //[DataRow(50d, 1480d, 16, 250d, 3, REMOTE_PASS, 14)]
        //public void TestTripleComparison(double investedValue, double valueA, int qtyPassA, double valueB, int qtyPassB, double valueC, int qtyPassC, int bestIdExpected, int[] passDifferenceExpectedArray)
        //{
        //    var config = getTriConfig((decimal)investedValue, (decimal)valueA, qtyPassA, (decimal)valueB, qtyPassB, (decimal)valueC, qtyPassC);

        //    var svc = new CalculatorService();
        //    var result = svc.CalculateBundles(config);

        //    Assert.IsTrue((result.BestBundle?.BundleId ?? 0) == bestIdExpected, $"BundleId from BestBundle is different: sent {result.BestBundle?.BundleId ?? 0}, expected {bestIdExpected}");

        //    int iteration = 0;
        //    foreach (var item in result.PassQuantityComparison)
        //    {
        //        Assert.IsTrue(item.BestBundleId == bestIdExpected, $"BundleId (iteration id: {iteration}) from comparison is different: sent {item.BestBundleId}, expected {bestIdExpected}");
        //        Assert.IsTrue(item.PassDifference == passDifferenceExpectedArray[iteration], $"Pass difference (iteration id: {iteration}) is different: {item.PassDifference} expected {passDifferenceExpectedArray[iteration]}");

        //        iteration++;
        //    }

        //}

        //private static CalculatorConfiguration getTriConfig(decimal investedValue, decimal valueA, int qtyPassA, decimal valueB, int qtyPassB, decimal valueC, int qtyPassC)
        //{
        //    CalculatorConfiguration c = new CalculatorConfiguration();
        //    c.InvestedValue = investedValue;
        //    c.BundlesToCompare = new List<Bundle>()
        //    {
        //        new Bundle()
        //        {
        //            PassQuantity = qtyPassA,
        //            PassType = Bundle.BundlePassType.Premium,
        //            Value = valueA
        //        },
        //        new Bundle()
        //        {
        //             Value = valueB,
        //             PassType = Bundle.BundlePassType.Remote,
        //             PassQuantity = qtyPassB
        //        },
        //        new Bundle()
        //        {
        //             Value = valueC,
        //             PassType = Bundle.BundlePassType.Premium,
        //             PassQuantity = qtyPassC
        //        }
        //    };

        //    return c;
        //}

    }
}
