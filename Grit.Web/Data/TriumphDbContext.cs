using System;
using Grit.Web.Entities;
using Microsoft.EntityFrameworkCore;

namespace Grit.Web.Data
{     public class TriumphDbContext : DbContext     {         public TriumphDbContext(DbContextOptions<TriumphDbContext> options)             : base(options)         {         }          public DbSet<Client> Clients { get; set; }         public DbSet<Project> Projects { get; set; }         public DbSet<Employee> Employees { get; set; }         public DbSet<Contact> Contacts { get; set; }     } }
