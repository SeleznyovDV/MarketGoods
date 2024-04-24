using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketGoods.Domain.Payments
{
    public enum PaymentStatus
    {
        Created,
        Pending,
        Processed,
        Canceled
    }
}
