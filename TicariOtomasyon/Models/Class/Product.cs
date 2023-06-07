using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Class
{
    public class Product
    {   [Key]
        public int ProductID { get; set; }
        [Column(TypeName="Varchar")]
        [StringLength(30)]
        public string ProductNAme { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Brand { get; set; }
        public int Stock { get; set; }
        public decimal Purchaseprice { get; set; }
        public decimal Saleprice { get; set; }
        public bool Situation { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string ProductImage { get; set; }
        public int Categoryiid { get; set; }
        public virtual Category Category { get; set; }
        public ICollection<SalesAction> SalesActions { get; set; }

    }


}