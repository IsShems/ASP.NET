namespace AzureTestTurboAz.Models
{
    public class ProductCategory
    {
        public int ProductCategoryID { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedDate { get; set; }
        public static IEnumerable<ProductCategory> Allcategories { get; set; }
    }
}
