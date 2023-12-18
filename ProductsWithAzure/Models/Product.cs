namespace AzureTestTurboAz.Models
{
    public class Product
    {
        private readonly AzureRepository _repository = new AzureRepository();
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public string Color { get; set; }
        public double StandardCost { get; set; }
        public double ListPrice { get; set; }
        public string Size { get; set; }
        public double Weight { get; set; }
        public int ProductCategoryId { get; set; }
        public int ProductModelId { get; set; }
        public DateTime SellStartDate { get; set; }
        public DateTime SellEndDate { get; set; }
        public DateTime DiscontinuedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public static Product pr { get; set; }
        public static IEnumerable<Product> Selectedproducts { get; set; } 
}
}
