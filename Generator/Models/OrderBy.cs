using SQLGenerator.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLGenerator.Models
{
    public class OrderBy
    {
        public string Field;
        public OrderType OrderType;

        public OrderBy(string field, OrderType orderType = OrderType.Asc)
        {
            Field = field;
            OrderType = orderType;
        }
    }
}
