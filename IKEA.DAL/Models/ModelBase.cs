﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Models
{
    public class ModelBase
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; } //Soft Delete
        public int CreatedBy { get; set; }
        public DateTime CreateOn { get; set; }
        public int LastModifiedBy { get; set; } 
        public DateTime LastModifiedOn { get; set; }



    }
}
