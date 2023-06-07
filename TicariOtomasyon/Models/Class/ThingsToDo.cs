using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Class
{
    public class ThingsToDo
    {
        [Key]
        public int ThingsToDoId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Header { get; set; }
       
        public bool Situation { get; set; }
     
    }
}