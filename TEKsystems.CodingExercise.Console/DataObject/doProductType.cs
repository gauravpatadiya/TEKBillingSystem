
namespace TEKsystems.CodingExercise.Console.DataObject
{
    /// <summary>
    /// This class is used to create a wrapper of database table object/File columns.
    /// Each property of an instance of this class represents a column of database table object/File columns.  
    /// </summary>
    public class doProductType
    {
        public string product_type { get; set; }
        public bool is_taxable { get; set; }
    }

    /// <summary>
    /// Enumeration for Product Type List
    /// </summary>
    public enum enmProductTypeList
    {
        Book,
        Food,
        Medical,
        Music,
        Perfume,
    }
}
