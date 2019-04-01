using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    public class Vklad
    {
        [Key]
        public int Vklad_id { get; set; }

       
        [Required]
        public int Balance { get; set; }

        public DateTime DateOpen { get; set; }

        public Prog Prog { get; set; } 
    }
}
