
namespace TEKsystems.CodingExercise.DataObject
{
    /// <summary>
    /// This class is used to create a wrapper of database table object/File columns.
    /// Each property of an instance of this class represents a column of database table object/File columns.  
    /// </summary>
    public class doProductList
    {
        public int product_id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string category_type { get; set; }
        public decimal base_price { get; set; }
        public bool is_imported { get; set; }
    }

    public enum enmProductList
    {
        product_id,
        code,
        name,
        category_type,
        base_price,
        is_imported,
    }
}
