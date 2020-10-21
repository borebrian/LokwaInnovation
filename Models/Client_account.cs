using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LokwaInnovation.Models
{
    public class Client_account
    {
        public string Token_balance { get; set; }
        public string Phone_number { get; set; }
        [Key]
        [Required]
        public int ID { get; set; }

    }

}
