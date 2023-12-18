using Microsoft.AspNetCore.Mvc;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AzureTestTurboAz.Models
{   
    public class AzureRepository
        {
            private IDbConnection _db;
            public AzureRepository()
            {
                _db = new SqlConnection();
                _db.ConnectionString =
                    @"Server=tcp:servershhh.database.windows.net,1433;Initial Catalog=shhh;Persist Security Info=False;User ID=shhh;Password=V5@KqVddVwXZ4bz;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            }

             public IEnumerable<Product> GetAllProduct()
             {
                var sql = "SELECT * FROM SalesLT.Product";
                return _db.Query<Product>(sql);
             }

             public IEnumerable<ProductCategory> GetAllProductCategory()
             {
                 var sql = "SELECT * FROM SalesLT.ProductCategory";
                 return _db.Query<ProductCategory>(sql);
             }

             public IEnumerable<Product> GetByCategory(int SelectedCategoryId)
             {    
                var sql = $"SELECT * FROM SalesLT.Product WHERE ProductCategoryID = '{SelectedCategoryId}'";
                return _db.Query<Product>(sql);
             }

             public Product GetProductById(int productId)
             {
                 var sql = $"SELECT * FROM SalesLT.Product WHERE ProductID = {productId}";
                 return _db.Query<Product>(sql).FirstOrDefault();
             }

    }
}
