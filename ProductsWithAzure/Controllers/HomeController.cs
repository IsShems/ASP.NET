using AzureTestTurboAz.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AzureTestTurboAz.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AzureRepository _repository = new AzureRepository();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int? categoryId, string sortOption)
        {
            var categories = _repository.GetAllProductCategory();
            ProductCategory.Allcategories = _repository.GetAllProductCategory();
            Product.Selectedproducts = _repository.GetAllProduct();
            var allProducts = _repository.GetAllProduct();
            string blobSasUrl = $"https://shhh.blob.core.windows.net/shhhblob/6fe36bb08118edb1c28f99513b32132f.jpg?sp=r&st=2023-12-18T17:50:59Z&se=2023-12-19T01:50:59Z&spr=https&sv=2022-11-02&sr=c&sig=l5XMoS2ajM%2BIHRaDdKmdx1khYKqND5RAs%2FClAGU3Qi8%3D";
            ViewBag.BlobSasUrl = blobSasUrl;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(int SelectedCategoryId)
        {
            if (SelectedCategoryId != 0)
                Product.Selectedproducts = _repository.GetByCategory(SelectedCategoryId);
            else
                Product.Selectedproducts = _repository.GetAllProduct();
             string blobSasUrl = $"https://shhh.blob.core.windows.net/shhhblob/6fe36bb08118edb1c28f99513b32132f.jpg?sp=r&st=2023-12-18T17:50:59Z&se=2023-12-19T01:50:59Z&spr=https&sv=2022-11-02&sr=c&sig=l5XMoS2ajM%2BIHRaDdKmdx1khYKqND5RAs%2FClAGU3Qi8%3D";
             ViewBag.BlobSasUrl = blobSasUrl;
            return View(Product.Selectedproducts);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ProductPage(int productId)
        {
            string blobSasUrl = $"https://shhh.blob.core.windows.net/shhhblob/6fe36bb08118edb1c28f99513b32132f.jpg?sp=r&st=2023-12-18T17:50:59Z&se=2023-12-19T01:50:59Z&spr=https&sv=2022-11-02&sr=c&sig=l5XMoS2ajM%2BIHRaDdKmdx1khYKqND5RAs%2FClAGU3Qi8%3D";
            ViewBag.BlobSasUrl = blobSasUrl;
            Product.pr = _repository.GetProductById(productId);

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
