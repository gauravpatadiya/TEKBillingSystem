
namespace TEKsystems.CodingExercise.Console.DataObject
{
    /// <summary>
    /// This class is used to create a wrapper of database table object/File columns.
    /// Each property of an instance of this class represents a column of database table object/File columns.  
    /// </summary>
    public class doTaxRateRef
    {
        public int tax_year { get; set; }
        public decimal tax_rate { get; set; }
        public decimal imported_rate { get; set; }
    }
}
