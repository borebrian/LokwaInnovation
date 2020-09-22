using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LokwaInnovation.Models
{
    public class Log_in
    {
        [Required]
        [Display(Name = "Full names", Prompt = "Full names")]
        public string Full_name { get; set; }



        [Required]
        [Display(Name = "Phone number")]
        [DataType(DataType.PhoneNumber)]
        public string Phone_number { get; set; }
        


     
        [Display(Name = "Email:", Prompt = "Email")]
        [DataType(DataType.EmailAddress)]

        public string Email { get; set; }



        [Required]
        [Display(Name = "Password:", Prompt = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }




        [Required]
        [Display(Name = "Date:", Prompt = "Date")]
        //[DataType(DataType.Date)]
        public string Date { get; set; }



        [Key]
        [Required]
        public int User_ID { get; set; } 
       
        
        [Required]
        public int Roles { get; set; }

    }

}
