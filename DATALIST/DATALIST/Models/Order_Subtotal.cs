﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DATALIST.Models
{
    public partial class Order_Subtotal
    {
        public int OrderID { get; set; }
        public decimal? Subtotal { get; set; }
    }
}
