using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AggregatorService
{
    public class MergerService : IMergerService
    {
        private readonly IConfiguration _configuration;
        const string UserServiceURLKey = "userServiceURL";
        const string OrderServiceURLKey = "orderServiceURL";


        public MergerService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<OrderDetails> GetOrderDetails(int id)
        {
            var orderDetail = new OrderDetails();
            using (var httpClient = new HttpClient())
            {
                using (var userResponse = await httpClient.GetAsync(_configuration[UserServiceURLKey] + id))
                {
                    orderDetail.UserDetails = await userResponse.Content.ReadAsAsync<User>();
                }

                using (var orderResponse = await httpClient.GetAsync(_configuration[OrderServiceURLKey] + id))
                {
                    orderDetail.Orders = await orderResponse.Content.ReadAsAsync<List<Orders>>();
                }

                return orderDetail;
            }
        }
    }
}
