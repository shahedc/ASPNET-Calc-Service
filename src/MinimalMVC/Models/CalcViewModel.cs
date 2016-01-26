using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MinimalMVC.Models
{
    public class CalcViewModel
    {
        [Display(Name = "Number 1")]
        public int Number1 { get; set; }
        [Display(Name = "Number 2")]
        public int Number2 { get; set; }
        public double Result { get; set; }
    }
}
