#region Namespaces

using System;
using System.Collections.ObjectModel;
using System.Text;
using TEKsystems.CodingExercise.Console.BusinessObject;
using TEKsystems.CodingExercise.Console.Utility;

#endregion

namespace TEKsystems.CodingExercise.Console
{
    /// <summary>
    /// Main Start Program of the application
    /// </summary>
    class TEKsystemsProgram
    {
        static void Main(string[] args)
        {
            Collection<boCart> lclcCart = new Collection<boCart>();

            AddDetailsToCart(lclcCart);
            PrintReceipt(lclcCart);
        }

        #region Private Method

        /// <summary>
        /// Prints the receipt.
        /// </summary>
        /// <param name="aclcCart">The cart.</param>
        private static void PrintReceipt(Collection<boCart> aclcCart)
        {
            StringBuilder lstrbReceiptData = ReceiptHelper.iobjInstance.GetReceiptDetails(aclcCart);
            System.Console.WriteLine(lstrbReceiptData);

            System.Console.WriteLine("Press ESC to quit ...");
            do
            {
                while (!System.Console.KeyAvailable) { }
            }
            while (System.Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// Adds the details to cart.
        /// </summary>
        /// <param name="aclcCart">The cart.</param>
        private static void AddDetailsToCart(Collection<boCart> aclcCart)
        {
            //Shopping Cart 1
            boCart iboCart1 = new boCart();
            iboCart1.AddProduct("BK01");
            iboCart1.AddProduct("MS01");
            iboCart1.AddProduct("FD01");
            aclcCart.Add(iboCart1);

            //Shopping Cart 2
            boCart iboCart2 = new boCart();
            iboCart2.AddProduct("FD02");
            iboCart2.AddProduct("PF01");
            aclcCart.Add(iboCart2);

            //Shopping Cart 3
            boCart iboCart3 = new boCart();
            iboCart3.AddProduct("PF02");
            iboCart3.AddProduct("PF03");
            iboCart3.AddProduct("MD04");
            iboCart3.AddProduct("FD03");
            aclcCart.Add(iboCart3);
        }

        #endregion
    }
}
