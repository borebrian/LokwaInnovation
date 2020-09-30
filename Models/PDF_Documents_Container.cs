using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lubes.Models
{
    public class PDF_Documents_Container
    {
        public int ID { get; set; }
        public string Document_name { get; set; }
        public string Document_description { get; set; }
        public string Book_url { get; set; }
        public string Cover_url { get; set; }
        public string Date_modified { get; set; } = DateTime.Now.ToString();

    }
}
