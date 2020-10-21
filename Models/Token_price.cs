using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LokwaInnovation.Models
{
    public class Token_price
    {

        [Key]
        public int ID { get; set; }
        public float Token_pricelist { get; set; }
        [DataType(DataType.Date)]
        public string DateModified { get; set; } = DateTime.Now.ToString();
    }

}
