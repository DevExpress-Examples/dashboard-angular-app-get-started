using System;
using System.Collections.Generic;

namespace AspNetCoreServer {
    public class Invoices {
        static Random rnd = new Random();
        public string Country { get; set; }
        public string City { get; set; }
        public string ProductName { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
        public double Discount { get; set; }
        public double ExtendedPrice { get; set; }
        public double Freigth { get; set; }
        public double UnitPrice { get; set; }

        public static List<Invoices> CreateData() {
            List<Invoices> data = new List<Invoices>();
data.Add(new Invoices { Country = "Germany", City = "Aachen", ProductName = "Raclette Courdavault", OrderDate = GenerateOrderDate(), Quantity = 30, Discount = 0, ExtendedPrice = 1650, Freigth = 149.47, UnitPrice = 55 });
            data.Add(new Invoices { Country = "Germany", City = "Berlin", ProductName = "Raclette Courdavault", OrderDate = GenerateOrderDate(), Quantity = 15, Discount = 0, ExtendedPrice = 825, Freigth = 69.53, UnitPrice = 55 });
            data.Add(new Invoices { Country = "Germany", City = "Brandenburg", ProductName = "Raclette Courdavault", OrderDate = GenerateOrderDate(), Quantity = 61, Discount = 0, ExtendedPrice = 2959, Freigth = 42.33, UnitPrice = 99 });
            data.Add(new Invoices { Country = "Germany", City = "Brandenburg", ProductName = "Raclette Courdavault", OrderDate = GenerateOrderDate(), Quantity = 24, Discount = 0, ExtendedPrice = 1320, Freigth = 29.59, UnitPrice = 55 });
            data.Add(new Invoices { Country = "Germany", City = "Cunewalde", ProductName = "Camembert Pierrot", OrderDate = GenerateOrderDate(), Quantity = 55, Discount = 0.1, ExtendedPrice = 1346.4, Freigth = 183.17, UnitPrice = 27.2 });
            data.Add(new Invoices { Country = "Germany", City = "Cunewalde", ProductName = "Camembert Pierrot", OrderDate = GenerateOrderDate(), Quantity = 139, Discount = 0.2, ExtendedPrice = 4204.1, Freigth = 568.62, UnitPrice = 68 });
data.Add(new Invoices { Country = "Germany", City = "Cunewalde", ProductName = "Camembert Pierrot", OrderDate = GenerateOrderDate(), Quantity = 49, Discount = 0.25, ExtendedPrice = 1249.5, Freigth = 31.89, UnitPrice = 34 });
            data.Add(new Invoices { Country = "Germany", City = "Cunewalde", ProductName = "Raclette Courdavault", OrderDate = GenerateOrderDate(), Quantity = 70, Discount = 0, ExtendedPrice = 3850, Freigth = 401.88, UnitPrice = 110 });
            data.Add(new Invoices { Country = "Germany", City = "Frankfurt a.M.", ProductName = "Camembert Pierrot", OrderDate = GenerateOrderDate(), Quantity = 20, Discount = 0.25, ExtendedPrice = 408, Freigth = 76.56, UnitPrice = 27.2 });
            data.Add(new Invoices { Country = "Germany", City = "Frankfurt a.M.", ProductName = "Camembert Pierrot", OrderDate = GenerateOrderDate(), Quantity = 35, Discount = 0.25, ExtendedPrice = 892.5, Freigth = 58.88, UnitPrice = 34 });
            data.Add(new Invoices { Country = "Germany", City = "Frankfurt a.M.", ProductName = "Raclette Courdavault", OrderDate = GenerateOrderDate(), Quantity = 25, Discount = 0, ExtendedPrice = 1375, Freigth = 91.28, UnitPrice = 55 });
            data.Add(new Invoices { Country = "Germany", City = "Cologne", ProductName = "Camembert Pierrot", OrderDate = GenerateOrderDate(), Quantity = 30, Discount = 0, ExtendedPrice = 1020, Freigth = 145.63, UnitPrice = 34 });
            data.Add(new Invoices { Country = "Germany", City = "Leipzig", ProductName = "Raclette Courdavault", OrderDate = GenerateOrderDate(), Quantity = 12, Discount = 0, ExtendedPrice = 660, Freigth = 127.34, UnitPrice = 55 });
            data.Add(new Invoices { Country = "Germany", City = "Mannheim", ProductName = "Camembert Pierrot", OrderDate = GenerateOrderDate(), Quantity = 21, Discount = 0, ExtendedPrice = 714, Freigth = 31.14, UnitPrice = 34 });
            data.Add(new Invoices { Country = "Germany", City = "Munich", ProductName = "Raclette Courdavault", OrderDate = GenerateOrderDate(), Quantity = 70, Discount = 0.15, ExtendedPrice = 2618, Freigth = 208.58, UnitPrice = 44 });
            data.Add(new Invoices { Country = "Germany", City = "Munich", ProductName = "Raclette Courdavault", OrderDate = GenerateOrderDate(), Quantity = 30, Discount = 0, ExtendedPrice = 1320, Freigth = 4.93, UnitPrice = 44 });
            data.Add(new Invoices { Country = "Germany", City = "Munich", ProductName = "Camembert Pierrot", OrderDate = GenerateOrderDate(), Quantity = 20, Discount = 0.1, ExtendedPrice = 612, Freigth = 93.25, UnitPrice = 34 });
            data.Add(new Invoices { Country = "Germany", City = "Munich", ProductName = "Camembert Pierrot", OrderDate = GenerateOrderDate(), Quantity = 36, Discount = 0.05, ExtendedPrice = 1162.8, Freigth = 242.95, UnitPrice = 34 });
            data.Add(new Invoices { Country = "USA", City = "Albuquerque", ProductName = "Raclette Courdavault", OrderDate = GenerateOrderDate(), Quantity = 60, Discount = 0, ExtendedPrice = 2640, Freigth = 708.95, UnitPrice = 44 });
            data.Add(new Invoices { Country = "USA", City = "Albuquerque", ProductName = "Camembert Pierrot", OrderDate = GenerateOrderDate(), Quantity = 21, Discount = 0, ExtendedPrice = 571.2, Freigth = 147.26, UnitPrice = 27.2 });
            data.Add(new Invoices { Country = "USA", City = "Albuquerque", ProductName = "Camembert Pierrot", OrderDate = GenerateOrderDate(), Quantity = 2, Discount = 0.06, ExtendedPrice = 63.92, Freigth = 8.53, UnitPrice = 34 });
            data.Add(new Invoices { Country = "USA", City ="Anchorage", ProductName = "Raclette Courdavault", OrderDate = GenerateOrderDate(), Quantity = 8, Discount = 0, ExtendedPrice = 440, Freigth = 135.63, UnitPrice = 55 });
            data.Add(new Invoices { Country = "USA", City = "Boise", ProductName = "Raclette Courdavault", OrderDate = GenerateOrderDate(), Quantity = 40, Discount = 0.15, ExtendedPrice = 1496, Freigth = 214.27, UnitPrice = 44 });
            data.Add(new Invoices { Country = "USA", City = "Boise", ProductName = "Raclette Courdavault", OrderDate = GenerateOrderDate(), Quantity = 7, Discount = 0, ExtendedPrice = 385, Freigth = 8.19, UnitPrice = 55 });
            data.Add(new Invoices { Country = "USA", City = "Boise", ProductName = "Raclette Courdavault", OrderDate = GenerateOrderDate(), Quantity = 100, Discount = 0.25, ExtendedPrice = 4125, Freigth = 830.75, UnitPrice = 55 });
            data.Add(new Invoices { Country = "USA", City = "Boise", ProductName = "Camembert Pierrot", OrderDate = GenerateOrderDate(), Quantity = 70, Discount = 0, ExtendedPrice = 2380, Freigth = 896.77, UnitPrice = 68 });
            data.Add(new Invoices { Country = "USA", City = "Boise", ProductName = "Camembert Pierrot", OrderDate = GenerateOrderDate(), Quantity = 45, Discount = 0.2, ExtendedPrice = 1224, Freigth = 487.57, UnitPrice = 34 });
            data.Add(new Invoices { Country = "USA", City = "Eugene", ProductName = "Raclette Courdavault", OrderDate = GenerateOrderDate(), Quantity = 30, Discount = 0.15, ExtendedPrice = 1402.5, Freigth = 18.53, UnitPrice = 55 });
            data.Add(new Invoices { Country = "USA", City = "Eugene", ProductName = "Camembert Pierrot", OrderDate = GenerateOrderDate(), Quantity = 15, Discount = 0, ExtendedPrice = 510, Freigth = 14.01, UnitPrice = 34 });
            data.Add(new Invoices { Country = "USA", City = "Lander", ProductName = "Camembert Pierrot", OrderDate = GenerateOrderDate(), Quantity = 20, Discount = 0.2, ExtendedPrice = 435.2, Freigth = 30.96, UnitPrice = 27.2 });
            data.Add(new Invoices { Country = "USA", City = "Portland", ProductName = "Raclette Courdavault", OrderDate = GenerateOrderDate(), Quantity = 1, Discount = 0, ExtendedPrice = 55, Freigth = 26.31, UnitPrice = 55 });
            data.Add(new Invoices { Country = "USA", City = "Seattle", ProductName = "Raclette Courdavault", OrderDate = GenerateOrderDate(), Quantity = 30, Discount = 0, ExtendedPrice = 1650, Freigth = 606.19, UnitPrice = 55 });
            return data;
        }

        static DateTime GenerateOrderDate() {
            int startYear = DateTime.Today.Year - 3;
            int endYear = DateTime.Today.Year;
            return new DateTime(rnd.Next(startYear, endYear), rnd.Next(1, 13), rnd.Next(1, 29));
        }
    }
}