//using Covid19Tracing.Models;
using LokwaInnovation.Models;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lubes.Models;

namespace LokwaInnovation.DBContext
{
    public class ApplicationDBContext : DbContext
    {
      
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
           : base(options)
        {

        }


        public DbSet<Contacts> AnonymousMessages { get; set; }
        public DbSet<Log_in> Log_in { get; set; }
        public DbSet<PDF_Documents> PDF_Documents { get; set; }

        public DbSet<Visits_counter> Visits_counter { get; set; }
        public DbSet<PDF_Refference> Pdf_refference { get; set; }
        public DbSet<Conversation> Conversation { get; set; }
        public DbSet<LokwaInnovation.Models.Messages> Messages { get; set; }
        public DbSet<LokwaInnovation.Models.Students> Students { get; set; }
        public DbSet<LokwaInnovation.Models.Client_account> Client_account { get; set; }
        public DbSet<LokwaInnovation.Models.MpesaTransactions> MpesaTransactions { get; set; }
        public DbSet<LokwaInnovation.Models.Mpesa_Status> Mpesa_Status { get; set; }
        public DbSet<LokwaInnovation.Models.Access_Tokens> Access_Tokens { get; set; }
       
     

       










    }
}
