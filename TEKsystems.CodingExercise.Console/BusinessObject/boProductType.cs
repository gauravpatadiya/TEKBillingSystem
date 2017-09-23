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
    /// This class store the business logic for Product Type
    /// </summary>
    /// <seealso cref="TEKsystems.CodingExercise.Console.BusinessObject.IProduct" />
    public class boProductType : IProduct
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="boProductType"/> class.
        /// </summary>
        public boProductType()
        {
            iclcProductType = new Collection<doProductType>();
            LoadDetailsFromFile();
        }

        #endregion

        #region Properties

        /// <summary>
        /// The product Type
        /// </summary>
        public Collection<doProductType> iclcProductType;

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the product list.
        /// </summary>
        /// <returns></returns>
        public void LoadDetailsFromFile()
        {
            //Get the Product list from the file
            List<string[]> llstProductType = ProductInventoryHelper.LoadFileData(ProductInventoryHelper.PRODUCT_TYPE_FILE_NAME);

            if (llstProductType != null)
            {
                //Create and fill Data object of Product Type
                foreach (string[] larrProductType in llstProductType)
                {
                    doProductType ldoProductType = new doProductType();
                    ldoProductType.product_type = larrProductType[0];
                    ldoProductType.is_taxable = Convert.ToBoolean(larrProductType[1]);

                    //Add to Product Type collection in order to get all the Product list in collection
                    iclcProductType.Add(ldoProductType);
                }
            }
        }

        #endregion
    }
}
