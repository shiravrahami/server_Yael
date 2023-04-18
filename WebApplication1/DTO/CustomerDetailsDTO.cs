﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.DTO
{
    public class CustomerDetailsDTO
    {
        public int ID { get; set; }
        public string CustomerEmail { get; set; }

        public string CustomerName { get; set; }

        public string CustomerID { get; set; }

        public string CustomerPhone { get; set; }

        public string CustomerAdress { get; set; }

        public bool CustomerIsPotential { get; set; }

        public bool CustomerIsDeleted { get; set; }
    }
}