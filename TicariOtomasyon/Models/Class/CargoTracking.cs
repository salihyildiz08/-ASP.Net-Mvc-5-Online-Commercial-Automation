using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Class
{
    public class CargoTracking
    {
        [Key]
        public int CargoTrakingId { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(10)]
        public string  CargoTrakingCode { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(100)]

        public string explanation_  { get; set; }
        public DateTime date_  { get; set; }
    }
}