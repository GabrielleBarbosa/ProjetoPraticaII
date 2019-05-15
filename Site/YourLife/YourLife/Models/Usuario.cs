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
        [Required, StringLength(30)]
        public int nickname { get; set; }
        [Required, StringLength(20)]
        public int senha { get; set; }
    }
}