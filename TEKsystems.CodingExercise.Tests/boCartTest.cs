#region Namespaces

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.ObjectModel;
using TEKsystems.CodingExercise.Console.BusinessObject;
using TEKsystems.CodingExercise.Console.Utility;

using System.Linq;

#endregion

namespace TEKsystems.CodingExercise.Tests
{
    /// <summary>
    /// Summary description for boCartTest
    /// </summary>
    [TestClass]
    public class boCartTest
    {
        #region Music Product

        /// <summary>
        /// Calculates the tax on non imported music product.
        /// </summary>
        [TestMethod]
        public void CalculateTaxOnNonImportedMusicProduct()
        {
            boCart iboCart = new boCart();
            iboCart.AddProduct("MS01");

            Assert.AreEqual(1.5m, TaxHelper.RoundingRule(iboCart.idecTotalTaxAmt));
        }

        /// <summary>
        /// Calculates the tax on imported music product.
        /// </summary>
        [TestMethod]
        public void CalculateTaxOnImportedMusicProduct()
        {
            boCart iboCart = new boCart();
            iboCart.AddProduct("MS03");

            Assert.AreEqual(2.85m, TaxHelper.RoundingRule(iboCart.idecTotalTaxAmt));
        }

        #endregion

        #region Food Product

        /// <summary>
        /// Calculates the tax on non imported food product.
        /// </summary>
        [TestMethod]
        public void CalculateTaxOnNonImportedFoodProduct()
        {
            boCart iboCart = new boCart();
            iboCart.AddProduct("FD01");

            Assert.AreEqual(0m, TaxHelper.RoundingRule(iboCart.idecTotalTaxAmt));
        }

        /// <summary>
        /// Calculates the tax on imported food product.
        /// </summary>
        [TestMethod]
        public void CalculateTaxOnImportedFoodProduct()
        {
            boCart iboCart = new boCart();
            iboCart.AddProduct("FD02");

            Assert.AreEqual(0.5m, TaxHelper.RoundingRule(iboCart.idecTotalTaxAmt));
        }

        #endregion

        #region Book Product

        /// <summary>
        /// Calculates the tax on non imported book product.
        /// </summary>
        [TestMethod]
        public void CalculateTaxOnNonImportedBookProduct()
        {
            boCart iboCart = new boCart();
            iboCart.AddProduct("FD01");

            Assert.AreEqual(0m, TaxHelper.RoundingRule(iboCart.idecTotalTaxAmt));
        }

        #endregion

        #region Medical Product

        /// <summary>
        /// Calculates the tax on non imported medical product.
        /// </summary>
        [TestMethod]
        public void CalculateTaxOnNonImportedMedicalProduct()
        {
            boCart iboCart = new boCart();
            iboCart.AddProduct("MD01");

            Assert.AreEqual(0m, TaxHelper.RoundingRule(iboCart.idecTotalTaxAmt));
        }

        /// <summary>
        /// Calculates the tax on imported medical product.
        /// </summary>
        [TestMethod]
        public void CalculateTaxOnImportedMedicalProduct()
        {
            boCart iboCart = new boCart();
            iboCart.AddProduct("MD03");

            Assert.AreEqual(0.55m, TaxHelper.RoundingRule(iboCart.idecTotalTaxAmt));
        }

        #endregion

        #region Perfume Product

        /// <summary>
        /// Calculates the tax on non imported Perfume product.
        /// </summary>
        [TestMethod]
        public void CalculateTaxOnNonImportedPerfumeProduct()
        {
            boCart iboCart = new boCart();
            iboCart.AddProduct("PF03");

            Assert.AreEqual(1.9m, TaxHelper.RoundingRule(iboCart.idecTotalTaxAmt));
        }

        /// <summary>
        /// Calculates the tax on imported Perfume product.
        /// </summary>
        [TestMethod]
        public void CalculateTaxOnImportedPerfumeProduct()
        {
            boCart iboCart = new boCart();
            iboCart.AddProduct("PF01");

            Assert.AreEqual(7.15m, TaxHelper.RoundingRule(iboCart.idecTotalTaxAmt));
        }

        #endregion

        #region Cart Test

        #region Cart 1

        /// <summary>
        /// Calculates the tax for cart 1.
        /// </summary>
        [TestMethod]
        public void CalculateTaxForCart1()
        {
            boCart iboCart = new boCart();
            iboCart.AddProduct("BK01");
            iboCart.AddProduct("MS01");
            iboCart.AddProduct("FD01");

            Assert.AreEqual(1.5m, TaxHelper.RoundingRule(iboCart.idecTotalTaxAmt));
        }

        /// <summary>
        /// Calculates the total amount with tax for cart 1.
        /// </summary>
        [TestMethod]
        public void CalculateTotalAmountWithTaxForCart1()
        {
            boCart iboCart = new boCart();
            iboCart.AddProduct("BK01");
            iboCart.AddProduct("MS01");
            iboCart.AddProduct("FD01");

            Assert.AreEqual(29.83m, TaxHelper.RoundingRule(iboCart.idecTotalAmt));
        }

        #endregion

        #region Cart 2

        /// <summary>
        /// Calculates the tax for cart 2.
        /// </summary>
        [TestMethod]
        public void CalculateTaxForCart2()
        {
            boCart iboCart = new boCart();
            iboCart.AddProduct("FD02");
            iboCart.AddProduct("PF01");

            Assert.AreEqual(7.65m, TaxHelper.RoundingRule(iboCart.idecTotalTaxAmt));
        }

        /// <summary>
        /// Calculates the total amount with tax for cart 2.
        /// </summary>
        [TestMethod]
        public void CalculateTotalAmountWithTaxForCart2()
        {
            boCart iboCart = new boCart();
            iboCart.AddProduct("FD02");
            iboCart.AddProduct("PF01");

            Assert.AreEqual(65.15m, TaxHelper.RoundingRule(iboCart.idecTotalAmt));
        }

        #endregion

        #region Cart 3

        /// <summary>
        /// Calculates the tax for cart 3.
        /// </summary>
        [TestMethod]
        public void CalculateTaxForCart3()
        {
            boCart iboCart = new boCart();
            iboCart.AddProduct("PF02");
            iboCart.AddProduct("PF03");
            iboCart.AddProduct("MD04");
            iboCart.AddProduct("FD03");

            Assert.AreEqual(6.70m, TaxHelper.RoundingRule(iboCart.idecTotalTaxAmt));
        }

        /// <summary>
        /// Calculates the total amount with tax for cart 3.
        /// </summary>
        [TestMethod]
        public void CalculateTotalAmountWithTaxForCart3()
        {
            boCart iboCart = new boCart();
            iboCart.AddProduct("PF02");
            iboCart.AddProduct("PF03");
            iboCart.AddProduct("MD04");
            iboCart.AddProduct("FD03");

            Assert.AreEqual(74.68m, TaxHelper.RoundingRule(iboCart.idecTotalAmt));
        }

        #endregion

        #region Cart 1,2,3

        /// <summary>
        /// Calculates the tax for cart 1_2_3.
        /// </summary>
        [TestMethod]
        public void CalculateTaxForCart1_2_3()
        {
            Collection<boCart> lclcCart = new Collection<boCart>();

            //Shopping Cart 1
            boCart iboCart1 = new boCart();
            iboCart1.AddProduct("BK01");
            iboCart1.AddProduct("MS01");
            iboCart1.AddProduct("FD01");
            lclcCart.Add(iboCart1);

            //Shopping Cart 2
            boCart iboCart2 = new boCart();
            iboCart2.AddProduct("FD02");
            iboCart2.AddProduct("PF01");
            lclcCart.Add(iboCart2);

            //Shopping Cart 3
            boCart iboCart3 = new boCart();
            iboCart3.AddProduct("PF02");
            iboCart3.AddProduct("PF03");
            iboCart3.AddProduct("MD04");
            iboCart3.AddProduct("FD03");
            lclcCart.Add(iboCart3);

            Assert.AreEqual(15.85m, TaxHelper.RoundingRule(lclcCart.Sum(x => x.idecTotalTaxAmt)));
        }

        /// <summary>
        /// Calculates the total amount with tax for cart 3.
        /// </summary>
        [TestMethod]
        public void CalculateTotalAmountWithTaxForCart1_2_3()
        {
            Collection<boCart> lclcCart = new Collection<boCart>();

            //Shopping Cart 1
            boCart iboCart1 = new boCart();
            iboCart1.AddProduct("BK01");
            iboCart1.AddProduct("MS01");
            iboCart1.AddProduct("FD01");
            lclcCart.Add(iboCart1);

            //Shopping Cart 2
            boCart iboCart2 = new boCart();
            iboCart2.AddProduct("FD02");
            iboCart2.AddProduct("PF01");
            lclcCart.Add(iboCart2);

            //Shopping Cart 3
            boCart iboCart3 = new boCart();
            iboCart3.AddProduct("PF02");
            iboCart3.AddProduct("PF03");
            iboCart3.AddProduct("MD04");
            iboCart3.AddProduct("FD03");
            lclcCart.Add(iboCart3);

            Assert.AreEqual(169.66m, TaxHelper.RoundingRule(lclcCart.Sum(x => x.idecTotalAmt)));
        }

        #endregion

        #endregion
    }
}
