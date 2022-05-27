using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwaggApp
{
    public class OrderItems
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string TShirtSize { get; set; }
        public DateTime  DateOfOrder {get; set;}
        public string TShirtColour { get; set;} 
        public string ShippingAddress {get;set;} 


       
    }
}
