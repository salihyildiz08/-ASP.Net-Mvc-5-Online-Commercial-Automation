using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Class
{
    public class Bills
    {
        [Key]
        public int BillsId { get; set; }
        
        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string BillsIdSerialNumber { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string BillsIdDeskNumber { get; set; }
        public DateTime Date_ { get; set; }
        public string TaxAdministration { get; set; }
        [Column(TypeName = "Char")]
        [StringLength(5)]
        public string Hour { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
       
        public string DeliveryArea { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Submitter { get; set; }
        public decimal TotalAmount { get; set; }
        public ICollection<InvoiceItem> InvoiceItems { get; set; }

    }
}