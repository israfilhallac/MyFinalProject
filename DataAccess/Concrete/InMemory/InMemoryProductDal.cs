using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            _products = new List<Product> {
                new Product{ProductId=1,CategoryId=1,ProductName="Masa",UnitPrice=20,UnitsInStock=5},
                     new Product{ProductId=2,CategoryId=2,ProductName="Vazo",UnitPrice=10,UnitsInStock=3},
                          new Product{ProductId=3,CategoryId=2,ProductName="Bardak",UnitPrice=5,UnitsInStock=8},
                               new Product{ProductId=4,CategoryId=1,ProductName="Sandalye",UnitPrice=25,UnitsInStock=10},
                                    new Product{ProductId=5,CategoryId=1,ProductName="Sehpa",UnitPrice=15,UnitsInStock=3}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Update(Product product)
        {
            // Gönderdiğim ürün Idsine sahip olan listedeki ürünü bul..
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }
    }
}
