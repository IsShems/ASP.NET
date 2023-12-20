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
            string blobSasUrl = $"https://url of blob :))";
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
             string blobSasUrl = $"https://url of blob :))";
             ViewBag.BlobSasUrl = blobSasUrl;
            return View(Product.Selectedproducts);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ProductPage(int productId)
        {
            string blobSasUrl = $"https://url of blob :))";
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
