
namespace TEKsystems.CodingExercise.Console.BusinessObject
{
    /// <summary>
    /// This class store the properties for current Product which added to the cart
    /// </summary>
    public class boProduct
    {
        #region Properties

        /// <summary>
        /// Gets or sets the product code.
        /// </summary>
        public string istrProductCode { get; set; }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        public string istrProductName { get; set; }

        /// <summary>
        /// Gets or sets the type of the product.
        /// </summary>
        public string istrProductType { get; set; }

        /// <summary>
        /// Gets or sets the base price.
        /// </summary>
        public decimal idecBasePrice { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is taxable].
        /// </summary>
        public bool iblnIsTaxable { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is imported].
        /// </summary>
        public bool iblnIsImported { get; set; }

        /// <summary>
        /// Gets or sets the product tax.
        /// </summary>
        public decimal idecProductTax { get; set; }

        #endregion
    }
}
