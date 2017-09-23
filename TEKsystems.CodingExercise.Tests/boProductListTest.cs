#region Namespaces

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using TEKsystems.CodingExercise.Console.BusinessObject;
using TEKsystems.CodingExercise.Console.DataObject;
using TEKsystems.CodingExercise.Console.Utility;

#endregion

namespace TEKsystems.CodingExercise.Tests
{
    /// <summary>
    /// Test the boProductList Functionalities
    /// </summary>
    [TestClass]
    public class boProductListTest
    {
        #region Properties

        /// <summary>
        /// The new line character
        /// </summary>
        public static string istrNewLineCharacter = Environment.NewLine;

        #endregion

        /// <summary>
        /// Checks the product list file count is not chaged.
        /// </summary>
        [TestMethod]
        public void CheckProductListFileCountIsNotChaged()
        {
            Collection<doProductList> lclcProductListTestData = CreateProductCollection();
            boProductList lboProductList = new boProductList();

            Assert.AreEqual(lclcProductListTestData.Count, lboProductList.iclcProductList.Count);
        }

        #region Mock Product Testing

        /// <summary>
        /// Checks the one mock product receipt.
        /// </summary>
        [TestMethod]
        public void CheckOneMockProductReceipt()
        {
            Mock<boCart> lobjMockCart = new Mock<boCart>();
            lobjMockCart.Setup(x => x.AddProduct("BK01"));

            Collection<boCart> lclcCart = new Collection<boCart>();

            //Create Product Object which will add to cart
            boProduct lboProduct = GetboProduct("TS01", "Test book 1", enmProductTypeList.Book.ToString(), 15.3m, false, true);

            lobjMockCart.Object.CalculateTaxAndAddToProductCart(lboProduct);
            if (lobjMockCart.Object.iclcCartProduct != null)
            {
                lclcCart.Add(lobjMockCart.Object);
            }

            StringBuilder lstrReceiptDetails = ReceiptHelper.iobjInstance.GetReceiptDetails(lclcCart);
            StringBuilder lstrExpectedReceiptDetails = GenerateTestReceiptData(lobjMockCart);

            Assert.AreEqual(lstrReceiptDetails.Equals(lstrExpectedReceiptDetails), true);
        }

        /// <summary>
        /// Checks the multiple mock product receipt.
        /// </summary>
        [TestMethod]
        public void CheckMultipleMockProductReceipt()
        {
            Mock<boCart> lobjMockCart = new Mock<boCart>();
            lobjMockCart.Setup(x => x.AddProduct("BK01"));

            Collection<boCart> lclcCart = new Collection<boCart>();

            //Create Product Object which will add to cart
            lobjMockCart.Object.CalculateTaxAndAddToProductCart(GetboProduct("TS01", "Test book 1", enmProductTypeList.Book.ToString(), 15.3m, false, false));
            lobjMockCart.Object.CalculateTaxAndAddToProductCart(GetboProduct("TS02", "Test Music 1", enmProductTypeList.Music.ToString(), 10.0m, true, true));
            lobjMockCart.Object.CalculateTaxAndAddToProductCart(GetboProduct("TS03", "Test Medical 1", enmProductTypeList.Medical.ToString(), 4.99m, false, true));
            lobjMockCart.Object.CalculateTaxAndAddToProductCart(GetboProduct("TS04", "Test Perfume 1", enmProductTypeList.Perfume.ToString(), 35.5m, true, false));
            if (lobjMockCart.Object.iclcCartProduct != null)
            {
                lclcCart.Add(lobjMockCart.Object);
            }

            StringBuilder lstrReceiptDetails = ReceiptHelper.iobjInstance.GetReceiptDetails(lclcCart);
            StringBuilder lstrExpectedReceiptDetails = GenerateTestReceiptData(lobjMockCart);

            Assert.AreEqual(lstrReceiptDetails.Equals(lstrExpectedReceiptDetails), true);
        }

        /// <summary>
        /// Calculates the mock product tax.
        /// </summary>
        [TestMethod]
        public void CalculateMockProductTax()
        {
            Mock<boCart> lobjMockCart = new Mock<boCart>();
            lobjMockCart.Setup(x => x.AddProduct("BK01"));

            Collection<boCart> lclcCart = new Collection<boCart>();

            //Create Product Object which will add to cart
            lobjMockCart.Object.CalculateTaxAndAddToProductCart(GetboProduct("TS01", "Test Medical 1", enmProductTypeList.Medical.ToString(), 29.3m, false, true));
            lobjMockCart.Object.CalculateTaxAndAddToProductCart(GetboProduct("TS02", "Test Perfume 1", enmProductTypeList.Perfume.ToString(), 22.8m, true, true));
            if (lobjMockCart.Object.iclcCartProduct != null)
            {
                lclcCart.Add(lobjMockCart.Object);
            }

            decimal ldecTotalTax = lclcCart.Sum(x => x.idecTotalTaxAmt);

            Assert.AreEqual(4.95m, ldecTotalTax);
        }

        /// <summary>
        /// Getboes the product.
        /// </summary>
        /// <param name="astrProductCode">The product code.</param>
        /// <param name="astrName">Name of the product.</param>
        /// <param name="astrCategoryType">Type of the category.</param>
        /// <param name="adecBasePrice">The base price.</param>
        /// <param name="ablnIsTaxable">if set to <c>true</c> [is taxable].</param>
        /// <param name="ablnIsImproted">if set to <c>true</c> [is improted].</param>
        /// <returns></returns>
        private boProduct GetboProduct(string astrProductCode, string astrName, string astrCategoryType,
            decimal adecBasePrice, bool ablnIsTaxable = false, bool ablnIsImproted = false)
        {
            boProduct lboProduct = new boProduct();
            lboProduct.istrProductCode = astrProductCode;
            lboProduct.istrProductName = astrName;
            lboProduct.istrProductType = astrCategoryType;
            lboProduct.idecBasePrice = adecBasePrice;
            lboProduct.iblnIsTaxable = ablnIsTaxable;
            lboProduct.iblnIsImported = ablnIsImproted;

            return lboProduct;
        }

        /// <summary>
        /// Generates the test receipt data.
        /// </summary>
        /// <param name="aobjMockCart">The mock cart.</param>
        /// <returns></returns>
        private static StringBuilder GenerateTestReceiptData(Mock<boCart> aobjMockCart)
        {
            StringBuilder lstrExpectedReceiptDetails = new StringBuilder();
            lstrExpectedReceiptDetails.Append("========================= TEKsystems =================================" + istrNewLineCharacter);
            lstrExpectedReceiptDetails.Append(istrNewLineCharacter + istrNewLineCharacter + "Receipt " + aobjMockCart.Object.GetCurrentCardId() + ":" + istrNewLineCharacter);
            lstrExpectedReceiptDetails.Append("-------------------------------------------------" + istrNewLineCharacter);

            if (aobjMockCart.Object.iclcCartProduct != null && aobjMockCart.Object.iclcCartProduct.Count > 0)
            {
                decimal ldecTotalTaxAmt = 0m;
                decimal ldecTotalAmt = 0m;

                foreach (boProduct lboCartProduct in aobjMockCart.Object.iclcCartProduct)
                {
                    lstrExpectedReceiptDetails.Append("1 ");

                    if (lboCartProduct.iblnIsImported)
                    {
                        lstrExpectedReceiptDetails.Append("imported ");
                    }

                    ldecTotalTaxAmt += lboCartProduct.idecProductTax;
                    ldecTotalAmt += (lboCartProduct.idecBasePrice + lboCartProduct.idecProductTax);

                    lstrExpectedReceiptDetails.Append(lboCartProduct.istrProductName + ": " + TaxHelper.RoundingRule(lboCartProduct.idecBasePrice + lboCartProduct.idecProductTax).ToString("$0.00") + istrNewLineCharacter);
                }

                lstrExpectedReceiptDetails.Append("-----------------------------" + istrNewLineCharacter);
                lstrExpectedReceiptDetails.Append("Sales Taxes: " + ldecTotalTaxAmt.ToString("$0.00") + Environment.NewLine);
                lstrExpectedReceiptDetails.Append("Total: " + ldecTotalAmt.ToString("$0.00"));
                lstrExpectedReceiptDetails.Append(istrNewLineCharacter + "-----------------------------" + istrNewLineCharacter);
            }

            return lstrExpectedReceiptDetails;
        }

        #endregion

        #region Create Test Product List Same as File

        /// <summary>
        /// Creates the product collection.
        /// </summary>
        /// <returns></returns>
        private Collection<doProductList> CreateProductCollection()
        {
            //PRODUCT_ID,CODE,NAME,CATEGORY_TYPE,BASE_PRICE,IS_IMPORTED
            //1,BK01,Harry Potter Part 1,Book,12.49,FALSE
            //2,BK02,Harry Potter Part 2,Book,22,FALSE
            //3,MS01,Music CD 1,Music,14.99,FALSE
            //4,MS02,Music CD 2,Music,9.99,FALSE
            //5,MS03,Music CD 3,Music,18.99,TRUE
            //6,FD01,Chocolate bar Type 1,Food,0.85,FALSE
            //7,FD02,Box of chocolates Type 1,Food,10,TRUE
            //8,FD03,Box of chocolates Type 2,Food,11.25,TRUE
            //9,PF01,Perfume Type 1,Perfume,47.5,TRUE
            //10,PF02,Perfume Type 2,Perfume,27.99,TRUE
            //11,PF03,Perfume Type 3,Perfume,18.99,FALSE
            //12,MD01,Medicine 1,Medical,2.99,FALSE
            //13,MD02,Medicine 2,Medical,0.88,FALSE
            //14,MD03,Medicine 3,Medical,10.45,TRUE

            Collection<doProductList> lclcProductList = new Collection<doProductList>();

            lclcProductList.Add(AddProductList(1, "BK01", "Harry Potter Part 1", enmProductTypeList.Book.ToString(), 12.49m));
            lclcProductList.Add(AddProductList(2, "BK02", "Harry Potter Part 2", enmProductTypeList.Book.ToString(), 22m));
            lclcProductList.Add(AddProductList(3, "MS01", "Music CD 1", enmProductTypeList.Music.ToString(), 14.49m));
            lclcProductList.Add(AddProductList(4, "MS02", "Music CD 2", enmProductTypeList.Music.ToString(), 9.99m));
            lclcProductList.Add(AddProductList(5, "MS03", "Music CD 3", enmProductTypeList.Music.ToString(), 18.99m, true));
            lclcProductList.Add(AddProductList(6, "FD01", "Chocolate bar Type 1", enmProductTypeList.Food.ToString(), 0.85m));
            lclcProductList.Add(AddProductList(7, "FD02", "Box of chocolates Type 1", enmProductTypeList.Food.ToString(), 10m, true));
            lclcProductList.Add(AddProductList(8, "FD03", "Box of chocolates Type 2", enmProductTypeList.Food.ToString(), 11.25m, true));
            lclcProductList.Add(AddProductList(9, "PF01", "Perfume Type 1", enmProductTypeList.Perfume.ToString(), 47.5m, true));
            lclcProductList.Add(AddProductList(10, "PF02", "Perfume Type 2", enmProductTypeList.Perfume.ToString(), 27.99m, true));
            lclcProductList.Add(AddProductList(11, "PF03", "Perfume Type 3", enmProductTypeList.Perfume.ToString(), 18.99m));
            lclcProductList.Add(AddProductList(12, "MD01", "Medicine 1", enmProductTypeList.Medical.ToString(), 2.99m));
            lclcProductList.Add(AddProductList(13, "MD02", "Medicine 2", enmProductTypeList.Medical.ToString(), 0.88m));
            lclcProductList.Add(AddProductList(14, "MD03", "Medicine 3", enmProductTypeList.Medical.ToString(), 10.45m, true));
            lclcProductList.Add(AddProductList(15, "MD04", "Packet of headache Pills", enmProductTypeList.Medical.ToString(), 0.75m));

            return lclcProductList;
        }

        /// <summary>
        /// Adds the product list.
        /// </summary>
        /// <param name="aintProductId">The product identifier.</param>
        /// <param name="astrProductCode">The product code.</param>
        /// <param name="astrName">Name of the product</param>
        /// <param name="astrCategoryType">Type of the category.</param>
        /// <param name="adecBasePrice">The base price.</param>
        /// <param name="ablnImproted">if set to <c>true</c> [improted].</param>
        /// <returns></returns>
        private doProductList AddProductList(int aintProductId, string astrProductCode,
            string astrName, string astrCategoryType, decimal adecBasePrice,
            bool ablnImproted = false)
        {
            doProductList ldoProductList = new doProductList();
            ldoProductList.product_id = aintProductId;
            ldoProductList.code = astrProductCode;
            ldoProductList.name = astrName;
            ldoProductList.category_type = astrCategoryType;
            ldoProductList.base_price = adecBasePrice;
            ldoProductList.is_imported = ablnImproted;

            return ldoProductList;
        }

        #endregion
    }
}
