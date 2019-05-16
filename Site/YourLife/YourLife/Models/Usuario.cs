using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace YourLife.Models
{
    public class Usuario
    {
        public int id { get; set; }
        [Required, StringLength(25)]
        public string nickname { get; set; }
        [Required, StringLength(25)]
        public string senha { get; set; }
    }
}