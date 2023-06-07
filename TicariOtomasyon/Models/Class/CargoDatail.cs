using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Class
{
    public class CargoDatail
    {
        [Key]
        public int CargoDatailId { get; set; }
        [Column(TypeName="VarChar")]
        [StringLength(300)]
        public string explanation_ { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(10)]

        public string trackingcode { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(20)]

        public string employee { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(20)]

        public string buyer { get; set; }
        
        public DateTime date_ { get; set; }
    }
}