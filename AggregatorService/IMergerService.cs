using System.Threading.Tasks;

namespace AggregatorService
{
    public interface IMergerService
    {
        Task<OrderDetails> GetOrderDetails(int id);
    }
}