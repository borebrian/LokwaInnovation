using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LokwaInnovation.Models
{
    public class Access_Tokens
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string User_id { get; set; }
        public float Balance { get; set; } = 0;
        public string DateModified { get; set; }
    }

}
