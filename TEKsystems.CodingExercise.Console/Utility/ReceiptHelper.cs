#region Namespaces

using System;
using System.Collections.ObjectModel;
using System.Text;
using TEKsystems.CodingExercise.Console.BusinessObject;

#endregion

namespace TEKsystems.CodingExercise.Console.Utility
{
    /// <summary>
    /// Recipt Print Helper
    /// </summary>
    public class ReceiptHelper
    {
        #region Properties

        /// <summary>
        /// The instance
        /// </summary>
        private static readonly Lazy<ReceiptHelper> _iobjInstance = new Lazy<ReceiptHelper>(() => new ReceiptHelper());

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static ReceiptHelper iobjInstance { get { return _iobjInstance.Value; } }

        /// <summary>
        /// The new line character
        /// </summary>
        public static string istrNewLineCharacter = Environment.NewLine;

        #endregion

        #region Constructor

        private ReceiptHelper()
        {

        }

        #endregion

        #region Pubic Method
       
        /// <summary>
        /// Gets the receipt details.
        /// </summary>
        /// <param name="aclbCart">The cart.</param>
        /// <returns></returns>
        public StringBuilder GetReceiptDetails(Collection<boCart> aclbCart)
        {
            StringBuilder lstrReceiptDetails = new StringBuilder();

            if (aclbCart != null)
            {
                lstrReceiptDetails.Append("========================= TEKsystems =================================" + istrNewLineCharacter);

                foreach (boCart lboCart in aclbCart)
                {
                    lstrReceiptDetails.Append(istrNewLineCharacter + istrNewLineCharacter + "Receipt " + lboCart.GetCurrentCardId() + ":" + istrNewLineCharacter);
                    lstrReceiptDetails.Append("-------------------------------------------------" + istrNewLineCharacter);

                    if (lboCart.iclcCartProduct != null && lboCart.iclcCartProduct.Count > 0)
                    {
                        decimal ldecTotalTaxAmt = 0m;
                        decimal ldecTotalAmt = 0m;

                        foreach (boProduct lboProduct in lboCart.iclcCartProduct)
                        {
                            lstrReceiptDetails.Append("1 ");

                            if (lboProduct.iblnIsImported)
                            {
                                lstrReceiptDetails.Append("imported ");
                            }

                            ldecTotalTaxAmt += lboProduct.idecProductTax;
                            ldecTotalAmt += (lboProduct.idecBasePrice + lboProduct.idecProductTax);

                            lstrReceiptDetails.Append(lboProduct.istrProductName + ": " + TaxHelper.RoundingRule(lboProduct.idecBasePrice + lboProduct.idecProductTax).ToString("$0.00") + istrNewLineCharacter);
                        }

                        lstrReceiptDetails.Append("-----------------------------" + istrNewLineCharacter);
                        lstrReceiptDetails.Append("Sales Taxes: " + ldecTotalTaxAmt.ToString("$0.00") + Environment.NewLine);
                        lstrReceiptDetails.Append("Total: " + ldecTotalAmt.ToString("$0.00"));
                        lstrReceiptDetails.Append(istrNewLineCharacter + "-----------------------------" + istrNewLineCharacter);
                    }
                }
            }

            return lstrReceiptDetails;
        }

        #endregion
    }
}
