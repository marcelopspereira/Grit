using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using WebApp.Models.AccountViewModel;
using WebApp.ViewModel;

namespace WebApp.Data
{     public class TriumphDbContext : IdentityDbContext     {
        public TriumphDbContext()
        {

        }

        public TriumphDbContext(DbContextOptions<TriumphDbContext> options)             : base(options)         {
         }
        //Base Level Entities
        public DbSet<Client> Clients { get; set; }         public DbSet<Project> Projects { get; set; }         public DbSet<Employee> Employees { get; set; }         public DbSet<Contact> Contacts { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<EmployeeNote> EmployeeNotes { get; set; }

        public DbSet<WebApp.Models.ApplicationUser> ApplicationUser { get; set; }

        public DbSet<WebApp.Models.Invent.Branch> Branch { get; set; }

        public DbSet<WebApp.Models.Invent.Warehouse> Warehouse { get; set; }

        public DbSet<WebApp.Models.Invent.Product> Product { get; set; }

        public DbSet<WebApp.Models.Invent.Vendor> Vendor { get; set; }

        public DbSet<WebApp.Models.Invent.VendorLine> VendorLine { get; set; }

        public DbSet<WebApp.Models.Invent.PurchaseOrder> PurchaseOrder { get; set; }

        public DbSet<WebApp.Models.Invent.PurchaseOrderLine> PurchaseOrderLine { get; set; }

        public DbSet<WebApp.Models.Invent.Customer> Customer { get; set; }

        public DbSet<WebApp.Models.Invent.CustomerLine> CustomerLine { get; set; }

        public DbSet<WebApp.Models.Invent.SalesOrder> SalesOrder { get; set; }

        public DbSet<WebApp.Models.Invent.SalesOrderLine> SalesOrderLine { get; set; }

        public DbSet<WebApp.Models.Invent.Shipment> Shipment { get; set; }

        public DbSet<WebApp.Models.Invent.ShipmentLine> ShipmentLine { get; set; }

        public DbSet<WebApp.Models.Invent.Receiving> Receiving { get; set; }

        public DbSet<WebApp.Models.Invent.ReceivingLine> ReceivingLine { get; set; }

        public DbSet<WebApp.Models.Invent.TransferOrder> TransferOrder { get; set; }

        public DbSet<WebApp.Models.Invent.TransferOrderLine> TransferOrderLine { get; set; }

        public DbSet<WebApp.Models.Invent.TransferOut> TransferOut { get; set; }

        public DbSet<WebApp.Models.Invent.TransferOutLine> TransferOutLine { get; set; }

        public DbSet<WebApp.Models.Invent.TransferIn> TransferIn { get; set; }

        public DbSet<WebApp.Models.Invent.TransferInLine> TransferInLine { get; set; }

        public DbSet<WebApp.Models.Crm.Rating> Rating { get; set; }

        public DbSet<WebApp.Models.Crm.Activity> Activity { get; set; }

        public DbSet<WebApp.Models.Crm.Channel> Channel { get; set; }

        public DbSet<WebApp.Models.Crm.Stage> Stage { get; set; }

        public DbSet<WebApp.Models.Crm.AccountExecutive> AccountExecutive { get; set; }

        public DbSet<WebApp.Models.Crm.Lead> Lead { get; set; }

        public DbSet<WebApp.Models.Crm.LeadLine> LeadLine { get; set; }

        public DbSet<WebApp.Models.Crm.Opportunity> Opportunity { get; set; }

        public DbSet<WebApp.Models.Crm.OpportunityLine> OpportunityLine { get; set; }
    } 
 }