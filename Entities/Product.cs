using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;

namespace StorageManager {
    class Product {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Product (){}
        public Product (string name, double price, int quantity){
            Name = name; Price = price; Quantity = quantity;
        }

        public double TotalPrice (){
            return Price * Quantity;
        }

        public override string ToString()
        {
            return Name
            + ","
            + Price
            + ","
            + Quantity
            + ",";
        }
    }
}