using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Class
{
    public class SalesAction
    {
        [Key]
        public int SalesActionId { get; set; }
        //product
        //current
        //employee
        public DateTime Date_ { get; set; }
        public int Piece { get; set; }
        public decimal Price { get; set; }
        public decimal TotalAmount { get; set; }
        public int  Productiid { get; set; }
        public int Currentiid { get; set; }
        public int Employeeiid { get; set; }

        public virtual Product Product { get; set; }
        public virtual Current Current { get; set; }
        public virtual Employee Employee { get; set; }
    }
}