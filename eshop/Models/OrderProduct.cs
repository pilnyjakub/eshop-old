﻿namespace eshop.Models
{
    public class OrderProduct
    {
        public int Id { get; set; }
        public int IdOrder { get; set; }
        public int IdProduct { get; set; }
        public int Quantity { get; set; }
    }
}
