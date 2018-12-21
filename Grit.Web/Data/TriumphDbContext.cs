using System;
using Grit.Web.Entities;
using Grit.Web.Entities.CRM;
using Grit.Web.Entities.CrmViewModels;
using Grit.Web.Entities.Invent;
using Microsoft.EntityFrameworkCore;

namespace Grit.Web.Data
{     public class TriumphDbContext : DbContext     {         public TriumphDbContext(DbContextOptions<TriumphDbContext> options)             : base(options)         {         }

        //Base Level Entities
        public DbSet<Client> Clients { get; set; }         public DbSet<Project> Projects { get; set; }         public DbSet<Employee> Employees { get; set; }         public DbSet<Contact> Contacts { get; set; }
        public DbSet<INetcoreBasic> INetCoreBasics { get; set; }
        public DbSet<INetcoreMasterChild> INetcoreMasterChilds { get; set; }

        //CRM Entities
        public DbSet<AccountExecutive> AccountExecutives { get; set; }
        public DbSet<Activity> Activity { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<Lead> Leads { get; set; }
        public DbSet<LeadLine> LeadLines { get; set; }
        public DbSet<Opportunity> Opportunities { get; set; }
        public DbSet<OpportunityLine> OpportunityLines { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Stage> Stages { get; set; }

        //CrmViewModel Entities
        public DbSet<RatingWidgetViewModel> RatingWidgetViewModels { get; set; }
        public DbSet<StageWidgetViewModel> StageWidgetViewModels { get; set; }

        //Invent Entities
        public DbSet<BaseSocialMedia> BaseSocialMedias { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<IBaseAddress> IBaseAddress { get; set; }     }
 }
