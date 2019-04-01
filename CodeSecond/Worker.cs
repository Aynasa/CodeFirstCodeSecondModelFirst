namespace CodeSecond
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Worker")]
    public partial class Worker
    {
        public Worker()
        {
                Client = new HashSet<Client>();
        }


        [Key]
        public int Worker_id { get; set; }

        [Required]
        [StringLength(50)]
        public string FIO { get; set; }

        [Required]
        [StringLength(50)]
        public string Position { get; set; }
        public virtual ICollection<Client> Client { get; set; }

    }
}
