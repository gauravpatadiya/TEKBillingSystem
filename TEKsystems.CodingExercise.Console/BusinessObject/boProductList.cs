#region Namespaces

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TEKsystems.CodingExercise.Console.DataObject;
using TEKsystems.CodingExercise.Console.Utility;

#endregion

namespace TEKsystems.CodingExercise.Console.BusinessObject
{
    /// <summary>
    /// Interface (Contract for Product, ProductType, TaxRateRef Class)
    /// </summary>
    interface IProduct
    {
        void LoadDetailsFromFile();
    }

    /// <summary>
    /// This class store the business logic for Product List
    /// </summary>
    /// <seealso cref="TEKsystems.CodingExercise.Console.BusinessObject.IProduct" />
    public class boProductList : IProduct
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="boProductList"/> class.
        /// </summary>
        public boProductList()
        {
            iclcProductList = new Collection<doProductList>();
            LoadDetailsFromFile();
        }

        #endregion

        #region Properties

        /// <summary>
        /// The product list
        /// </summary>
        public Collection<doProductList> iclcProductList;

        #endregion

        #region Private Methods

        /// <summary>
        /// Gets the product list.
        /// </summary>
        /// <returns></returns>
        public void LoadDetailsFromFile()
        {
            //Get the Product list from the file
            List<string[]> llstProductList = ProductInventoryHelper.LoadFileData(ProductInventoryHelper.PRODUCT_LIST_FILE_NAME);

            if (llstProductList != null)
            {
                foreach (string[] larrProduct in llstProductList)
                {
                    //Create and fill Data object of Product List
                    doProductList ldoProductList = new doProductList();
                    ldoProductList.code = larrProduct[1];
                    ldoProductList.name = larrProduct[2];
                    ldoProductList.category_type = larrProduct[3];
                    ldoProductList.base_price = Convert.ToDecimal(larrProduct[4]);
                    ldoProductList.is_imported = Convert.ToBoolean(larrProduct[5]);

                    //Add to Product List collection in order to get all the Product list in collection
                    iclcProductList.Add(ldoProductList);
                }
            }
        }

        #endregion
    }
}
