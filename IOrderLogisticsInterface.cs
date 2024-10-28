using ClassWork4.OrderClass;

namespace ClassWork4.IOrderLogisticsInterface
{
    public interface IOrderLogistics
    {
        void ProcessOrder(Order order);
        void ChangeOrderStatus(int orderId, string newStatus);
        void UpdateProductQuantity(int productId, int quantityChange);
    }
}
