using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LokwaInnovation.Models
{
    public class Mpesa_Status
    {

       
        public string User_id { get; set; }
        public float Ammount { get; set; } = 0;
        public string TransactionDate { get; set; }
        public string strResultCode { get; set; }
        public string ResultDesc { get; set; }
        public string CheckoutRequestID { get; set; }
        public string transactionCode { get; set; }
        public Boolean Payment_status { get; set; } = false;
        public Boolean Transaction_status { get; set; } = false;
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

    }

}
