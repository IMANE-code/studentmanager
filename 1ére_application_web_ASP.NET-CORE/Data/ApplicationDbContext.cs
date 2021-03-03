using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using _1ére_application_web_ASP.NET_CORE.Models;

namespace _1ére_application_web_ASP.NET_CORE.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<_1ére_application_web_ASP.NET_CORE.Models.etudiant> etudiant { get; set; }
    }
}
