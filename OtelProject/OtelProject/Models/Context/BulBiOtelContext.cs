using OtelProject.Models.Tables;
using System;
using System.Collections.Generic;
#pragma warning disable CS0234 // The type or namespace name 'Entity' does not exist in the namespace 'System.Data' (are you missing an assembly reference?)
using System.Data.Entity;
#pragma warning restore CS0234 // The type or namespace name 'Entity' does not exist in the namespace 'System.Data' (are you missing an assembly reference?)
using System.Linq;
using System.Web;

namespace OtelProject.Models.Context
{
#pragma warning disable CS0246 // The type or namespace name 'DbContext' could not be found (are you missing a using directive or an assembly reference?)
    public class BulBiOtelContext : DbContext
#pragma warning restore CS0246 // The type or namespace name 'DbContext' could not be found (are you missing a using directive or an assembly reference?)
    {
#pragma warning disable CS0246 // The type or namespace name 'DbSet<>' could not be found (are you missing a using directive or an assembly reference?)
        public DbSet<Otel> Otels { get; set; }
#pragma warning restore CS0246 // The type or namespace name 'DbSet<>' could not be found (are you missing a using directive or an assembly reference?)
#pragma warning disable CS0246 // The type or namespace name 'DbSet<>' could not be found (are you missing a using directive or an assembly reference?)
        public DbSet<Country> Countries { get; set; }
#pragma warning restore CS0246 // The type or namespace name 'DbSet<>' could not be found (are you missing a using directive or an assembly reference?)
#pragma warning disable CS0246 // The type or namespace name 'DbSet<>' could not be found (are you missing a using directive or an assembly reference?)
        public DbSet<Admin> Admins { get; set; }
#pragma warning restore CS0246 // The type or namespace name 'DbSet<>' could not be found (are you missing a using directive or an assembly reference?)
#pragma warning disable CS0246 // The type or namespace name 'DbSet<>' could not be found (are you missing a using directive or an assembly reference?)
        public DbSet<LogRecord> LogRecords { get; set; }
#pragma warning restore CS0246 // The type or namespace name 'DbSet<>' could not be found (are you missing a using directive or an assembly reference?)
#pragma warning disable CS0246 // The type or namespace name 'DbSet<>' could not be found (are you missing a using directive or an assembly reference?)
        public DbSet<OtelUser> OtelUsers { get; set; }
#pragma warning restore CS0246 // The type or namespace name 'DbSet<>' could not be found (are you missing a using directive or an assembly reference?)

    }
}