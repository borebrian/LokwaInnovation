using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LokwaInnovation.Models
{
    public class MpesaTransactions
    {

       
        public string Amount { get; set; }
        public string MpesaReceiptNumber { get; set; }
        public string TransactionDate { get; set; }
        public string PhoneNumber { get; set; }
      
       
        [Key]
        [Required]
        public int ID { get; set; }

    }

}
