using ClassWork4.ProductClass;

namespace ClassWork4.ProductCatalogClass
{
    public class ProductCatalog
    {
        private Dictionary<int, Product> _products = new Dictionary<int, Product>();

        public void AddProduct(Product product)
        {
            if (!_products.ContainsKey(product.Id))
            {
                _products.Add(product.Id, product);
            }
            else
            {
                throw new Exception("Товар с таким ID уже существует");
            }
        }

        public void RemoveProduct(int productId)
        {
            if (_products.ContainsKey(productId))
            {
                _products.Remove(productId);
            }
            else
            {
                throw new Exception("Товар с таким ID не найден");
            }
        }

        public Product GetProduct(int productId)
        {
            if (_products.ContainsKey(productId))
            {
                return _products[productId];
            }
            throw new Exception("Товар с таким ID не найден");
        }

        public Dictionary<int, Product> GetAllProducts()
        {
            return _products;
        }
        public void DecreaseProductQuantity(int productId, int quantity)
        {
            if (_products.ContainsKey(productId))
            {
                _products[productId].Quantity -= quantity;
                if (_products[productId].Quantity < 0)
                {
                    _products[productId].Quantity = 0;
                    throw new Exception("Недостаточно товара на складе");
                }
            }
            else
            {
                throw new Exception("Товар с таким ID не найден");
            }
        }

        public void IncreaseProductQuantity(int productId, int quantity)
        {
            if (_products.ContainsKey(productId))
            {
                _products[productId].Quantity += quantity;
            }
            else
            {
                throw new Exception("Tовар с таким ID не найден");
            }
        }
    }
}
