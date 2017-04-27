namespace finalEvent.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class database_firewall_rules
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Key]
        [Column(Order = 1)]
        public string name { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(45)]
        public string start_ip_address { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(45)]
        public string end_ip_address { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime create_date { get; set; }

        [Key]
        [Column(Order = 5)]
        public DateTime modify_date { get; set; }
    }
}
