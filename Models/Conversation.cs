using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LokwaInnovation.Models
{
    public class Conversation
    {

        [Required]
        public  string chatID { get; set; }
        [Required]
        public Boolean status { get; set; }
        [Key]
        [Required]
        public int ID { get; set; }

    }

}
