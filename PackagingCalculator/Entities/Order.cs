﻿using System;
using System.Collections.Generic;

namespace PackagingCalculator.Entities
{
    public class Order
    {
        public long OrderID { get; set; }

        public List<Item> Items { get; set; }

        public double RequiredBinWidth { get; set; }
    }
}
