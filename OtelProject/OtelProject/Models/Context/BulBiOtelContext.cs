using OtelProject.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OtelProject.Models.Context
{
    public class BulBiOtelContext : DbContext
    {
        public DbSet<Otel> Otels { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<LogRecord> LogRecords { get; set; }
        public DbSet<OtelUser> OtelUsers { get; set; }
    }
}