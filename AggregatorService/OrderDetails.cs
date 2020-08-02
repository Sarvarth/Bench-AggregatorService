using System.Collections.Generic;

namespace AggregatorService
{
    public class OrderDetails
    {
        public User UserDetails { get; set; }
        public List<Orders> Orders{ get; set; }
    }
}
