using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Model.DTO;
using Utility;

namespace Model.Entity
{
    public  class Product 
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public DateTime? AddDate { get; set; }



    }
}
