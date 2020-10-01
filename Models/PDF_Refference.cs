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
        public int ID { get; set; }

        [Display(Name = "PDF Reff:", Prompt = "Document reff no")]

        [Required]

        public int Doc_id { get; set; }

        //[Display(Name = "Document description :", Prompt = "Document description ")]
        //[Required]
        //[MaxLength(50)]
        //public string  Document_description { get; set; }
        [Display(Name = "Enter refference description:", Prompt = "Refference description")]

        [Required]
        public string Description { get; set; }

        [Display(Name = "Select refference image :", Prompt = "Drag and drop here ")]

        [Required]
        [NotMapped]

        public IFormFile Image { get; set; }
        public string Refference_url { get; set; }
        [NotMapped]
        public string Date_modified { get; set; } = DateTime.Now.ToString();
     
    }
}
