using ClassWork4.IOrderLogisticsInterface;
using ClassWork4.ProductCatalogClass;
using ClassWork4.ProductClass;

namespace ClassWork4.OrderClass
{
    public class Order : IOrderLogistics
    {
        private Queue<Order> _orderQueue = new Queue<Order>();
        private Stack<Order> _completedOrders = new Stack<Order>();
        private Dictionary<int, string> _orderStatuses = new Dictionary<int, string>();
        private ProductCatalog _productCatalog = new ProductCatalog();

        private int _id;
        private string _customerName;
        private List<Product> _products = new List<Product>();
        private decimal _totalCost;

        public Order(int id, string customerName)
        {
            _id = id;
            _customerName = customerName;
        }

        public int Id
        {
            get { return _id; }
        }

        public string CustomerName
        {
            get { return _customerName; }
        }

        public List<Product> Products
        {
            get { return _products; }
        }

        public decimal TotalCost
        {
            get { return _totalCost; }
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
            _totalCost += product.Price;
        }
        public void AddOrder(Order order)
        {
            _orderQueue.Enqueue(order);
            _orderStatuses.Add(order.Id, "новый");
        }

        public Order GetNextOrder()
        {
            if (_orderQueue.Count == 0)
            {
                return null;
            }
            Order nextOrder = _orderQueue.Dequeue();
            ChangeOrderStatus(nextOrder.Id, "обрабатывается");
            return nextOrder;
        }

        public void MarkOrderAsCompleted(Order order)
        {
            _completedOrders.Push(order);
            ChangeOrderStatus(order.Id, "завершён");
        }

        public Stack<Order> GetCompletedOrders()
        {
            return _completedOrders;
        }

        public void ChangeOrderStatus(int orderId, string newStatus)
        {
            if (_orderStatuses.ContainsKey(orderId))
            {
                _orderStatuses[orderId] = newStatus;
            }
        }

        public string GetOrderStatus(int orderId)
        {
            if (_orderStatuses.ContainsKey(orderId))
            {
                return _orderStatuses[orderId];
            }
            return "неизвестный";
        }

        public void ProcessOrder(Order order)
        {
            foreach (Product product in order.Products)
            {
                if (_productCatalog.GetProduct(product.Id) == null || _productCatalog.GetProduct(product.Id).Quantity < product.Quantity)
                {
                    Console.WriteLine($"Недостаточно товара с ID: {product.Id}");
                    return;
                }
            }

            foreach (Product product in order.Products)
            {
                _productCatalog.DecreaseProductQuantity(product.Id, product.Quantity);
            }

            ChangeOrderStatus(order.Id, "обрабатывается");

            MarkOrderAsCompleted(order);
        }

        public void UpdateProductQuantity(int productId, int quantityChange)
        {
            _productCatalog.IncreaseProductQuantity(productId, quantityChange);
        }

    }

}
