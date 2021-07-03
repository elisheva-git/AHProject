using System;
using System.Collections.Generic;

#nullable disable

namespace AHProject.Models
{
    public partial class TblProduct
    {
        public TblProduct()
        {
            TblOrders = new HashSet<TblOrder>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double? Price { get; set; }
        public int? CategoryId { get; set; }

        public virtual ICollection<TblOrder> TblOrders { get; set; }
    }
}
