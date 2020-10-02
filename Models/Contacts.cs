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

        
        [Display(Name = "Names/Nick name", Prompt = "Name/Nick name")]
        public string Full_name { get; set; }
      
        [Required]
        [Display(Name = "Phone number", Prompt = "Phone number")]
        [DataType(DataType.PhoneNumber)]
        public string Phone_number { get; set; }


        
        [Display(Name = "Subject:", Prompt = "Subject")]
        public string Subject { get; set; } 


        [Required]
        [Display(Name = "Message:", Prompt = "Message")]
        public string Message { get; set; } 
        
        [Required]
        public  Boolean status { get; set; }= false;

        [Required]
        public Boolean Roles { get; set; } = false;
       
        public String Time { get; set; } 

        [Key]
        [Required]
        public int ID { get; set; }

    }

}
