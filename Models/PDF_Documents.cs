using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lubes.Models
{
    public class PDF_Documents
    {

        [Key]
        [Required]
        public int ID { get; set; }

        [Display(Name = "Document name :", Prompt = "Document name")]
        [Required]
        [MaxLength(50)]

        public string Document_name { get; set; }

        [Display(Name = "Document description :", Prompt = "Document description ")]
        [Required]
        [MaxLength(50)]
        public string  Document_description { get; set; }

        [Display(Name = "Upload your document in pdf format:")]
        [Required]
        [NotMapped]

        public IFormFile Document { get; set; }
        public string Book_url { get; set; }


        [Display(Name = "Upload your book cover image")]
        [Required]
        [NotMapped]

        public IFormFile Cover_image { get; set; }
        public string Cover_url { get; set; }
        public string Date_modified { get; set; } = DateTime.Now.ToString();
      



        //[Display(Name = "Upload Image:", Prompt = "Upload image")]
        //[Required(ErrorMessage = "Please choose profile image")]
    
        //public IFormFile Category_picture { get; set; }
    }
}
