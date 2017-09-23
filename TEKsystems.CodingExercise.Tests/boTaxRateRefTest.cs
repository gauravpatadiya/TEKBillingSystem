#region Namespaces

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.ObjectModel;
using TEKsystems.CodingExercise.Console.DataObject;
using TEKsystems.CodingExercise.Console.BusinessObject;
using System.Linq;

#endregion

namespace TEKsystems.CodingExercise.Tests
{
    /// <summary>
    /// Test the boTaxRateRefTest Functionalities 
    /// </summary>
    [TestClass]
    public class boTaxRateRefTest
    {
        /// <summary>
        /// Checks the Tax Rate Ref file count is not chaged.
        /// </summary>
        [TestMethod]
        public void CheckTaxRateRefFileCountIsNotChaged()
        {
            Collection<doTaxRateRef> lclcTaxRateRef = CreateTaxRateRefCollection();
            boTaxRateRef lboTaxRateRef = new boTaxRateRef();

            Assert.AreEqual(lclcTaxRateRef.Count, lboTaxRateRef.iclcTaxRateRef.Count);
        }

        /// <summary>
        /// Checks the tax rate for 2017 is 10 percentage.
        /// </summary>
        [TestMethod]
        public void CheckTaxRateFor2017Is10Percentage()
        {
            boTaxRateRef lboTaxRateRef = new boTaxRateRef();
            decimal ldecTaxRate = lboTaxRateRef.iclcTaxRateRef.Where(x => x.tax_year == 2017).FirstOrDefault().tax_rate;
            Assert.AreEqual(ldecTaxRate, 0.1m);
        }

        /// <summary>
        /// Checks the Import rate for 2017 is 5 percentage.
        /// </summary>
        [TestMethod]
        public void CheckImportRateFor2017Is5Percentage()
        {
            boTaxRateRef lboTaxRateRef = new boTaxRateRef();
            decimal ldecImportRate = lboTaxRateRef.iclcTaxRateRef.Where(x => x.tax_year == 2017).FirstOrDefault().imported_rate;
            Assert.AreEqual(ldecImportRate, 0.05m);
        }

        #region Create Test Tax Rate Ref Same as File

        /// <summary>
        /// Creates the Tax Rate Ref collection.
        /// </summary>
        /// <returns></returns>
        private Collection<doTaxRateRef> CreateTaxRateRefCollection()
        {
            //TAX_YEAR,TAX_RATE,IMPORTED_RATE
            //2016,0.1,0.08
            //2017,0.1,0.05

            Collection<doTaxRateRef> lclcTaxRateRef = new Collection<doTaxRateRef>();
            lclcTaxRateRef.Add(AddTaxRateRef(2016, 0.1m, 0.08m));
            lclcTaxRateRef.Add(AddTaxRateRef(2017, 0.1m, 0.05m));

            return lclcTaxRateRef;
        }

        /// <summary>
        /// Adds the tax rate reference.
        /// </summary>
        /// <param name="aintTaxYear">The aint tax year.</param>
        /// <param name="adecTaxRate">The adec tax rate.</param>
        /// <param name="adecImportedRates">The adec imported rates.</param>
        /// <returns></returns>
        private doTaxRateRef AddTaxRateRef(int aintTaxYear, decimal adecTaxRate, decimal adecImportedRates)
        {
            doTaxRateRef ldoTaxRateRef = new doTaxRateRef();
            ldoTaxRateRef.tax_year = aintTaxYear;
            ldoTaxRateRef.tax_rate = adecTaxRate;
            ldoTaxRateRef.imported_rate = adecImportedRates;

            return ldoTaxRateRef;
        }

        #endregion
    }
}
