﻿using IKEA.DAL.Common.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Dto_s.Employees
{
    public class CreateEmployeeDto
    {
        [MaxLength(50,ErrorMessage ="Max Length Of Name is 50 Chars")]
        [MinLength(5,ErrorMessage ="Min Length Of Name is 50 Chars")]
        public string Name { get; set; }

        [Range(22,30)]
        public int? Age { get; set; }

        //[RegularExpression(@"^[0-9]{1,3}-[a-zA-Z]{4,10}-[a-zA-Z]{5,10}$",ErrorMessage ="Address must be like 123-Street-City-Country")]
        public string? Address { get; set; }

        public decimal Salary { get; set; }

        [Display(Name ="Is Active")]
        public bool IsActive { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
   
        [Display(Name ="Phone Number")]
        [Phone]
        public string? PhoneNumber { get; set; }

        public DateOnly HiringDate { get; set; }

        public Gender Gender { get; set; }

        public EmployeeType EmployeeType { get; set; }
    }
}
