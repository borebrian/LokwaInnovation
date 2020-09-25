//using Covid19Tracing.Models;
using LokwaInnovation.Models;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public DbSet<Visits_counter> Visits_counter { get; set; }











    }
}
