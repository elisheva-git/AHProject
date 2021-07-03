using System;
using System.Collections.Generic;

#nullable disable

namespace AHProject.Models
{
    public partial class TblOrder
    {
        public int OrdNum { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? CustomerId { get; set; }
        public int DiscountPercent { get; set; }

        public virtual TblProduct Product { get; set; }
    }
}
