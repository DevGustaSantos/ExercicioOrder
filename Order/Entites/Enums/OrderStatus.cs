using System;
using Order.Entites;

namespace Order.Entites.Enums
{
    enum OrderStatus :int
    {
        Pending_Paymet = 0,
        Processing = 1,
        Shipped = 2,
        Delivered = 3
    }
}
