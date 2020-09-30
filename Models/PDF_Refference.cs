using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lubes.Models
{
    public class PDF_Refference
    {

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        //[Display(Name = "Document name :", Prompt = "Document name")]
        //[Required]
        //[MaxLength(50)]

        //public string Document_name { get; set; }

        //[Display(Name = "Document description :", Prompt = "Document description ")]
        //[Required]
        //[MaxLength(50)]
        //public string  Document_description { get; set; }

        [Display(Name = "Select refference image:")]
        [Required]
        [NotMapped]

        public IFormFile Image { get; set; }
        public string   Refference_url { get; set; }


        public string Cover_url { get; set; }
        public string Date_modified { get; set; } = DateTime.Now.ToString();
      



        //[Display(Name = "Upload Image:", Prompt = "Upload image")]
        //[Required(ErrorMessage = "Please choose profile image")]
    
        //public IFormFile Category_picture { get; set; }
    }
}
