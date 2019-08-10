/*
AUTHOR: Cyrus Alatraca
ID: 991146084
DATE: July 11, 2019
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PopYourself.Model
{
    public class Item
    {
        public string ItemName { get; set; }

        public string ItemCategory { get; set; }

        public string ItemDescription { get; set; }

        public string ItemImage { get; set; }

        public string ItemPhone { get; set; }

        public decimal ItemPrice { get; set; }
    }
}