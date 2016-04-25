using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ChildEdcuation.Models
{
    public class StudentModels
    {
        [Required]
        public string ID { get; set; }


        [Required]
        [Display(Name="姓名")]

        public string Name { get;set;}

        [Display(Name="年龄")]
        public int Age { get; set; }


        [Display(Name="住址")]
        public string Address { get; set; }
    }
}