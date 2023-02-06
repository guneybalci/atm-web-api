using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class AtmContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=MSKK-HCM-LT6548\SQLEXPRESS;Database=ATM;Trusted_Connection=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Customer

            modelBuilder.Entity<Customer>()
              .Property(c => c.CustomerID)
              .HasColumnName("Id")
               .UseIdentityColumn(1, 1)
              .IsRequired();

            modelBuilder.Entity<Customer>()
             .Property(c => c.CustomerName)
             .HasColumnName("CustomerName")
             .HasMaxLength(50);

            modelBuilder.Entity<Customer>()
             .Property(c => c.CustomerSurname)
             .HasColumnName("CustomerSurname")
             .HasMaxLength(50);

            modelBuilder.Entity<Customer>()
           .Property(c => c.CustomerPasskey)
           .HasColumnName("CustomerPasskey")
           .HasMaxLength(50);

            modelBuilder.Entity<Customer>()
           .Property(c => c.Balance)
           .HasColumnName("Balance");


            modelBuilder.Entity<Customer>()
      .Property(c => c.BalanceType)
      .HasColumnName("BalanceType")
      .HasColumnType("tinyint");

            modelBuilder.Entity<Customer>()
   .Property(c => c.IsActive)
   .HasColumnName("isActive")
   .HasDefaultValue(true);


            modelBuilder.Entity<Customer>()
            .HasMany<Transaction>(c => c.Transactions)
            .WithOne(t => t.Customer)
            .HasForeignKey(t => t.CustomerID);



            // Transaction

            modelBuilder.Entity<Transaction>()
             .Property(t => t.TransactionID)
             .HasColumnName("TransactionID")
               .UseIdentityColumn(1, 1);


            modelBuilder.Entity<Transaction>()
             .Property(t => t.TransactionNo)
                .HasColumnName("TransactionNo")
                .HasDefaultValue(10000);


            modelBuilder.Entity<Transaction>()
           .Property(t => t.TransactionAmount)
           .HasColumnName("TransactionAmount")
           .HasPrecision(18, 4);


            modelBuilder.Entity<Transaction>()
.Property(t => t.TransactionDate)
.HasColumnName("TransactionDate")
.HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Transaction>()
.Property(t => t.IsSuccess)
.HasColumnName("isSuccess")
.ValueGeneratedNever().HasDefaultValue(true);


            modelBuilder.Entity<Transaction>()
                .HasOne<Customer>(t => t.Customer)
                .WithMany(c => c.Transactions)
                .HasForeignKey(t => t.CustomerID);



            //User

            modelBuilder.Entity<User>()
          .Property(u => u.Id)
            .UseIdentityColumn(1, 1)
              .IsRequired();

            modelBuilder.Entity<User>()
            .Property(u => u.FirstName)
            .HasColumnName("FirstName")
            .HasMaxLength(50);

            modelBuilder.Entity<User>()
      .Property(u => u.LastName)
      .HasColumnName("LastName")
      .HasMaxLength(50);

            modelBuilder.Entity<User>()
  .Property(u => u.Email)
  .HasColumnName("Email")
  .HasMaxLength(50);

            modelBuilder.Entity<User>()
.Property(u => u.Status)
.HasColumnName("Status")
.ValueGeneratedNever().HasDefaultValue(null);

            modelBuilder.Entity<User>()
.Property(u => u.PasswordSalt)
.HasColumnName("PasswordSalt")
.HasMaxLength(500)
.HasColumnType("varbinary");

            modelBuilder.Entity<User>()
.Property(u => u.PasswordHash)
.HasColumnName("PasswordHash")
.HasMaxLength(500)
.HasColumnType("varbinary");


            //OperationClaims

            modelBuilder.Entity<OperationClaim>()
          .Property(o => o.Id)
          .HasColumnName("Id")
          .UseIdentityColumn(1, 1)
          .IsRequired();

            modelBuilder.Entity<OperationClaim>()
           .Property(o => o.Name)
           .HasColumnName("Name")
           .HasMaxLength(500);

            //UserOperationClaims

            modelBuilder.Entity<UserOperationClaim>()
       .Property(u => u.Id)
       .HasColumnName("Id")
        .UseIdentityColumn(1, 1)
       .IsRequired();


            modelBuilder.Entity<UserOperationClaim>()
       .Property(u => u.UserId)
        .ValueGeneratedOnAdd()
        .HasColumnName("UserId")
        .HasDefaultValueSql("1");

            modelBuilder.Entity<UserOperationClaim>()
       .Property(u => u.OperationClaimId)
        .ValueGeneratedOnAdd()
        .HasColumnName("OperationClaimId")
        .HasDefaultValueSql("1");


        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
