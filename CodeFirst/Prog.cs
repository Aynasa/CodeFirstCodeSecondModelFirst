using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    public class Prog
    {
        
        public Prog()
        {
            this.Vklads = new HashSet<Vklad>();
        }

        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Prog_id { get; set; }

        [Required]
        [StringLength(50)]
        public string Prog_name { get; set; }

        [Required]
        public int Percent { get; set; }

        public virtual ICollection <Vklad> Vklads{ get; set; }
    }
}
