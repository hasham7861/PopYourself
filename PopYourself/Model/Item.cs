//AUTHOR: Cyrus Alatraca
//ID: 991146084
//DATE: July 17, 2019
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PopYourself.Model
{
    public class Item
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public decimal Price { get; set; }
    }
}