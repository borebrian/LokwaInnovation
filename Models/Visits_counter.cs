using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LokwaInnovation.Models
{
    public class Visits_counter
    {
       

        [Required]
        //[DataType(DataType.Date)]
        public string Date { get; set; }
        
        [Required]
        //[DataType(DataType.Date)]
        public string Role { get; set; }

        [Key]
        [Required]
        public int Visit_id { get; set; } 
       
        
       

    }

}
