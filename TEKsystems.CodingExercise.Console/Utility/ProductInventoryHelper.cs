#region Namespaces

using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

#endregion

namespace TEKsystems.CodingExercise.Console.Utility
{
    /// <summary>
    /// Product Inventory Helper
    /// </summary>
    public static class ProductInventoryHelper
    {
        #region File Name Constants

        public static string PRODUCT_LIST_FILE_NAME = "Product_List.csv";
        public static string PRODUCT_TYPE_FILE_NAME = "Product_Type.csv";
        public static string TAX_RATE_REF_FILE_NAME = "Tax_Rate_Ref.csv";

        #endregion

        #region Get File Data From CSV File

        /// <summary>
        /// Gets the file data based on file name.
        /// </summary>
        /// <param name="astrFileName">Name of the file.</param>
        public static List<string[]> LoadFileData(string astrFileName)
        {
            //Get File path from the App.config
            string lstrFilePath = ConfigurationManager.AppSettings["file_path"].ToString();

            //Get File name from the App.`config
            string lstrFileNameWithPath = Path.Combine(lstrFilePath, astrFileName);

            try
            {
                //Check if the file is exists
                if (File.Exists(lstrFileNameWithPath))
                {
                    //Skip 1st row of header
                    return File.ReadLines(lstrFileNameWithPath).Skip(1).Select(data => data.Split(',')).ToList();
                }
            }
            catch (Exception)
            {
                //File not found
            }

            return null;
        }

        #endregion
    }
}
