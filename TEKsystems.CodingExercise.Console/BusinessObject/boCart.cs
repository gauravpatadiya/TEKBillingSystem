#region Namespaces

using System;
using System.Collections.ObjectModel;
using System.Linq;
using TEKsystems.CodingExercise.Console.DataObject;
using TEKsystems.CodingExercise.Console.Utility;

#endregion

namespace TEKsystems.CodingExercise.Console.BusinessObject
{
    /// <summary>
    /// This class store the business logic for Manipulating cart
    /// </summary>
    public class boCart
    {
        #region Properties

        /// <summary>
        /// The instance
        /// </summary>
        private static int _iintInstance = 0;

        /// <summary>
        /// The cart identifier
        /// </summary>
        private int _iintCartID = 0;

        /// <summary>
        /// Gets or sets the total tax amt.
        /// </summary>
        public decimal idecTotalTaxAmt { get; set; }

        /// <summary>
        /// Gets or sets the total amt.
        /// </summary>
        public decimal idecTotalAmt { get; set; }

        /// <summary>
        /// The product list
        /// </summary>
        boProductList iboProductList;

        /// <summary>
        /// The product type
        /// </summary>
        boProductType iboProductType;

        /// <summary>
        /// The tax rate reference
        /// </summary>
        boTaxRateRef iboTaxRateRef;

        /// <summary>
        /// Gets or sets the cart.
        /// </summary>
        public Collection<boProduct> iclcCartProduct { get; set; }

        /// <summary>
        /// Gets or sets the current tax rate.
        /// </summary>
        public decimal idecCurrentTaxRate { get; set; }

        /// <summary>
        /// Gets or sets the imported rate.
        /// </summary>
        public decimal idecImportedRate { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="boCart"/> class.
        /// </summary>
        public boCart()
        {
            //Store Current Instance ID
            _iintCartID = _iintInstance + 1;
            ++_iintInstance;

            //Along with initialization the Details are also loaded into the collection from the files
            iboProductList = new boProductList();
            iboProductType = new boProductType();
            iboTaxRateRef = new boTaxRateRef();

            iclcCartProduct = new Collection<boProduct>();

            //Set Current year's tax which will get from the file
            SetCurrentYearTaxRates();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the current card identifier.
        /// </summary>
        /// <returns></returns>
        public int GetCurrentCardId()
        {
            return _iintCartID;
        }

        /// <summary>
        /// Adds the product.
        /// </summary>
        /// <param name="astrProductCode">The product code.</param>
        public virtual void AddProduct(string astrProductCode)
        {
            if (this.iboProductList != null)
            {
                //Get Product List Detail by the Product Code
                doProductList ldoProductList = this.iboProductList.iclcProductList.Where(x => string.Equals(x.code, astrProductCode)).FirstOrDefault();

                if (ldoProductList != null)
                {
                    //Create Product Object which will add to cart
                    boProduct lboProduct = new boProduct();

                    lboProduct.istrProductCode = ldoProductList.code;
                    lboProduct.istrProductName = ldoProductList.name;
                    lboProduct.istrProductType = ldoProductList.category_type;
                    lboProduct.idecBasePrice = ldoProductList.base_price;
                    //Check if product is taxable from Product Type list
                    if (this.iboProductType.iclcProductType != null)
                    {
                        lboProduct.iblnIsTaxable = this.iboProductType.iclcProductType.Where(x => string.Equals(x.product_type, ldoProductList.category_type)).FirstOrDefault().is_taxable;
                    }
                    else
                    {
                        //If detail not available then we will set default to true
                        lboProduct.iblnIsTaxable = true;
                    }

                    lboProduct.iblnIsImported = ldoProductList.is_imported;

                    CalculateTaxAndAddToProductCart(lboProduct);
                }
            }
        }

        /// <summary>
        /// Calculates the tax and add to product cart.
        /// </summary>
        /// <param name="aboProduct">The abo product.</param>
        public void CalculateTaxAndAddToProductCart(boProduct aboProduct)
        {
            aboProduct.idecProductTax = 0m;

            decimal ldecTax = TaxHelper.CalculateTax(aboProduct, idecCurrentTaxRate, idecImportedRate);
            aboProduct.idecProductTax += ldecTax;

            //Add All Product Taxes
            idecTotalTaxAmt += aboProduct.idecProductTax;

            //Add total amount and taxes
            idecTotalAmt += (aboProduct.idecBasePrice + ldecTax);

            //Add Product to Cart
            iclcCartProduct.Add(aboProduct);
        }

        #endregion

        #region Private Method

        /// <summary>
        /// Sets the current year tax rates.
        /// </summary>
        private void SetCurrentYearTaxRates()
        {
            if (iboTaxRateRef.iclcTaxRateRef != null)
            {
                doTaxRateRef ldoCurrentTaxRate = this.iboTaxRateRef.iclcTaxRateRef.Where(x => x.tax_year == DateTime.Now.Year).FirstOrDefault();
                this.idecCurrentTaxRate = ldoCurrentTaxRate.tax_rate;
                this.idecImportedRate = ldoCurrentTaxRate.imported_rate;
            }
        }

        #endregion
    }
}
