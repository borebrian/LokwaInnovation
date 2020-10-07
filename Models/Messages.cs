using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LokwaInnovation.Models
{
    public class Messages
    {

      
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Subject { get; set; }

        public string Date { get; set; }
        [Required]
        [Display(Name = "Message:", Prompt = "Message")]
        public string Message { get; set; } 
        
        [Required]
        public  Boolean status { get; set; }= false;
        
        [Required]
        public  int chatID { get; set; }

        [Key]
        [Required]
        public int ID { get; set; }

    }

}
