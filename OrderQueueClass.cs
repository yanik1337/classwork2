using ClassWork4.OrderClass;

namespace ClassWork4.OrderQueueClass
{
    public class OrderQueue
    {
        private Queue<Order> _orderQueue = new Queue<Order>();
        private Stack<Order> _completedOrders = new Stack<Order>();
        private Dictionary<int, string> _orderStatuses = new Dictionary<int, string>();

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
    }


}
