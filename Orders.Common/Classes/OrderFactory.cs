using Orders.Common.Records;
namespace Orders.Common.Classes;

public class OrderFactory
{
    public List<Order> Orders { get; } = new ();
    public void Add(string customerName, string address)
    {
        try
        {
            Orders.Add(new Order(Orders.Count+1, customerName, address));
        }
        catch { throw; }
    }
    public List<Order> Get() => Orders;
    public Order? Latest () => Orders.LastOrDefault();
}
