
namespace TEKsystems.CodingExercise.DataObject
{
    public class doProductType
    {
        public int product_type { get; set; }
        public bool is_taxable { get; set; }
    }

    public enum enmProductType
    {
        product_type,
        is_taxable,
    }

    public enum enmProductTypeList
    {
        Book,
        Food,
        Medical,
        Music,
        Perfume,
    }
}
