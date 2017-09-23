#region Namespaces

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.ObjectModel;
using TEKsystems.CodingExercise.Console.DataObject;
using TEKsystems.CodingExercise.Console.BusinessObject;
using System;
using System.Linq;

#endregion

namespace TEKsystems.CodingExercise.Tests
{
    /// <summary>
    /// Test the boProductType Functionalities
    /// </summary>
    [TestClass]
    public class boProductTypeTest
    {
        /// <summary>
        /// Checks the product Type file count is not chaged.
        /// </summary>
        [TestMethod]
        public void CheckProductTypeFileCountIsNotChaged()
        {
            Collection<doProductType> lclcProductTypeTestData = CreateProductTypeCollection();
            boProductType lboProductType = new boProductType();

            Assert.AreEqual(lclcProductTypeTestData.Count, lboProductType.iclcProductType.Count);
        }

        /// <summary>
        /// Checks the product type file and enum count equal.
        /// </summary>
        [TestMethod]
        public void CheckProductTypeFileAndEnumCountEqual()
        {
            boProductType lboProductType = new boProductType();
            bool lblnIsEqual = false;
            if (Enum.GetNames(typeof(enmProductTypeList)).Length == lboProductType.iclcProductType.Count)
                lblnIsEqual = true;

            Assert.AreEqual(lblnIsEqual, true);
        }

        /// <summary>
        /// Checks the product type are medical book food perfume music.
        /// </summary>
        [TestMethod]
        public void CheckProductTypeAreMedical_Book_Food_Perfume_Music()
        {
            boProductType lboProductType = new boProductType();

            bool lblnIsExists = true;
            foreach (enmProductTypeList lenmProductTypeList in Enum.GetValues(typeof(enmProductTypeList)))
            {
                if (!lboProductType.iclcProductType.Any(x => string.Equals(x.product_type, lenmProductTypeList.ToString())))
                {
                    lblnIsExists = false;
                    break;
                }
            }

            Assert.AreEqual(lblnIsExists, true);
        }

        /// <summary>
        /// Checks the product type are sport not available.
        /// </summary>
        [TestMethod]
        public void CheckProductTypeAreSportNotAvailable()
        {
            boProductType lboProductType = new boProductType();

            bool lblnIsExists = false;

            if (lboProductType.iclcProductType.Any(x => string.Equals(x.product_type, "Sport")))
            {
                lblnIsExists = true;
            }

            Assert.AreNotEqual(lblnIsExists, true);
        }

        #region Create Test Product Type Same as File

        /// <summary>
        /// Creates the product collection.
        /// </summary>
        /// <returns></returns>
        private Collection<doProductType> CreateProductTypeCollection()
        {
            //PRODUCT_TYPE,IS_TAXABLE
            //Book,FALSE
            //Food,FALSE
            //Medical,FALSE
            //Music,TRUE
            //Perfume,TRUE

            Collection<doProductType> lclcProductType = new Collection<doProductType>();
            lclcProductType.Add(AddProductList(enmProductTypeList.Book.ToString()));
            lclcProductType.Add(AddProductList(enmProductTypeList.Food.ToString()));
            lclcProductType.Add(AddProductList(enmProductTypeList.Medical.ToString()));
            lclcProductType.Add(AddProductList(enmProductTypeList.Music.ToString(), true));
            lclcProductType.Add(AddProductList(enmProductTypeList.Perfume.ToString(), true));

            return lclcProductType;
        }

        /// <summary>
        /// Adds the product Type.
        /// </summary>
        /// <param name="astrProductType">Type of the product.</param>
        /// <param name="ablnIsTaxable">if set to <c>true</c> [is taxable].</param>
        /// <returns></returns>
        private doProductType AddProductList(string astrProductType, bool ablnIsTaxable = false)
        {
            doProductType ldoProductType = new doProductType();
            ldoProductType.product_type = astrProductType;
            ldoProductType.is_taxable = ablnIsTaxable;

            return ldoProductType;
        }

        #endregion
    }
}
