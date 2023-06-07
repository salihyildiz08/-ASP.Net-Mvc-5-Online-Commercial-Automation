using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Class
{
    public class massages
    {
        [Key]
        public int MessageID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string sender { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string buyer { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string subject { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(2000)]
        public string contents { get; set; }

        [Column(TypeName = "Date")]
        public DateTime _Date { get; set; }

    }
}