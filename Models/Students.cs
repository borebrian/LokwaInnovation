using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LokwaInnovation.Models
{
    public class Students
    {

        
        [Display(Name = "Names/Nick name", Prompt = "Name/Nick name")]
        [DataType(DataType.Text)]
        [Required]
        public string Full_name { get; set; }




        [Required]
        [Display(Name = "Phone number", Prompt = "Phone number")]
        [DataType(DataType.PhoneNumber)]
        public string Phone_number { get; set; }


        
        [Display(Name = "Subject:", Prompt = "Subject")]
        public string Subject { get; set; } 


        [Required]
       [DataType(DataType.PhoneNumber)]
        public string Roles { get; set; }
       
 
        [Required]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

    }

}
