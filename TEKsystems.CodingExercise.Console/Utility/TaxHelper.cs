#region Namespaces

using System;
using TEKsystems.CodingExercise.Console.BusinessObject;

#endregion

namespace TEKsystems.CodingExercise.Console.Utility
{
    /// <summary>
    /// Tax Calculator Helper
    /// </summary>
    public static class TaxHelper
    {
        #region Public Methods

        /// <summary>
        /// Calculates the tax.
        /// </summary>
        /// <param name="aboProduct">The product.</param>
        /// <param name="adecCurrentTaxRate">The current tax rate.</param>
        /// <param name="adecCurrentImportedRate">The current imported rate.</param>
        public static decimal CalculateTax(boProduct aboProduct, decimal adecCurrentTaxRate, decimal adecCurrentImportedRate)
        {
            decimal ldecCalculatedTax = 0m;

            if (aboProduct.iblnIsTaxable)
            {
                //Calculate Tax
                ldecCalculatedTax += (aboProduct.idecBasePrice * adecCurrentTaxRate);
            }

            if (aboProduct.iblnIsImported)
            {
                //Calculate Imported Tax
                ldecCalculatedTax += (aboProduct.idecBasePrice * adecCurrentImportedRate);
            }

            return TaxHelper.RoundingToNearest05Rule(ldecCalculatedTax);
        }


        /// <summary>
        /// Roundings the rule.
        /// </summary>
        /// <param name="adecTaxAmount">The tax amount.</param>
        /// <returns></returns>
        public static decimal RoundingRule(decimal adecTaxAmount)
        {
            return Math.Round(adecTaxAmount, 2, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// Roundings to nearest 05 rule.
        /// </summary>
        /// <param name="adecTaxAmount">The tax amount.</param>
        /// <returns></returns>
        public static decimal RoundingToNearest05Rule(decimal adecTaxAmount)
        {
            var lvarCeiling = Math.Ceiling(adecTaxAmount * 20);
            if (lvarCeiling == 0)
            {
                return 0;
            }

            return lvarCeiling / 20;
        }

        #endregion
    }
}
