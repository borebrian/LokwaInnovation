using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LokwaInnovation.Models
{
    public class Contacts
    {

        [Required]
        [Display(Name = "Full names", Prompt = "Full names")]
        public string Full_name { get; set; }
      
        [Required]
        [Display(Name = "Phone number", Prompt = "Phone number")]
        [DataType(DataType.PhoneNumber)]
        public string Subject { get; set; }
        

        [Required]
        [Display(Name = "Subject:", Prompt = "Subject")]
        [DataType(DataType.Password)]

        public string Date { get; set; }
        [Required]
        [Display(Name = "Message:", Prompt = "Message")]
        public string Message { get; set; } 
        
        [Required]
      
        public  Boolean status { get; set; }= false;

        [Key]
        [Required]
        public int ID { get; set; }

    }

}
