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
    /// This class store the business logic for Tax Rate Ref
    /// </summary>
    /// <seealso cref="TEKsystems.CodingExercise.Console.BusinessObject.IProduct" />
    public class boTaxRateRef : IProduct
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="boTaxRateRef"/> class.
        /// </summary>
        public boTaxRateRef()
        {
            iclcTaxRateRef = new Collection<doTaxRateRef>();
            LoadDetailsFromFile();
        }

        #endregion

        #region Properties

        /// <summary>
        /// The Tax Rate Ref
        /// </summary>
        public Collection<doTaxRateRef> iclcTaxRateRef;

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the Tax Rate Ref Details.
        /// </summary>
        /// <returns></returns>
        public void LoadDetailsFromFile()
        {
            //Get the Tax Rate Ref from the file
            List<string[]> llstTaxRateRef = ProductInventoryHelper.LoadFileData(ProductInventoryHelper.TAX_RATE_REF_FILE_NAME);

            if (llstTaxRateRef != null)
            {
                //Create and fill Data object of Tax Rate Ref
                foreach (string[] larrTaxRate in llstTaxRateRef)
                {
                    doTaxRateRef ldoTaxRateRef = new doTaxRateRef();
                    ldoTaxRateRef.tax_year = Convert.ToInt32(larrTaxRate[0]);
                    ldoTaxRateRef.tax_rate = Convert.ToDecimal(larrTaxRate[1]);
                    ldoTaxRateRef.imported_rate = Convert.ToDecimal(larrTaxRate[2]);

                    //Add to Tax Rate Ref collection in order to get all the Product list in collection
                    iclcTaxRateRef.Add(ldoTaxRateRef);
                }
            }
        }

        #endregion
    }
}
