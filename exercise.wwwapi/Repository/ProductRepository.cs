using exercise.wwwapi.Models;
using exercise.wwwapi.Models.Data;

namespace exercise.wwwapi.Repository
{
    public class ProductRepository : IProductRepository
    {
        DataContext _db;
        public ProductRepository(DataContext db)
        {
            _db = db;
        }
        public Product AddProduct(Product product)
        {
            //return ProductCollection.AddProduct(product);
            _db.Add(product);
            _db.SaveChanges();
            return product;
        }

        public Product DeleteProduct(int id)
        {
            //return ProductCollection.DeleteProduct(id);
            var product = _db.Products.FirstOrDefault(p => p.Id == id) as Product;
           _db.Products.Remove(product);
            _db.SaveChanges();
            return product;

        }

        public List<Product> GetAll(string category)
        {
            //return ProductCollection.GetProducts(category);
            return _db.Products.ToList();
        }

        public Product GetProduct(int id)
        {
            //return ProductCollection.GetProduct(id);
            var product = _db.Products.FirstOrDefault(p => p.Id == id) as Product;
            return product;
        }

        public Product UpdateProduct(int id, Product product)
        {
            //return ProductCollection.UpdateProduct(id, product);
            Product thisProduct = _db.Products.FirstOrDefault(p => p.Id == id);
            if (thisProduct != null)
            {
                _db.Entry(thisProduct).Property(p=> p.Name).CurrentValue = product.Name;
                _db.Entry(thisProduct).Property(p=> p.Category).CurrentValue = product.Category;
                _db.Entry(thisProduct).Property(p=> p.Price).CurrentValue = product.Price;
            }
            _db.SaveChanges();
            return thisProduct;
        }
    }
}
