using Microsoft.EntityFrameworkCore;
using Gianoli_BankApp.Models.Entities;

namespace Gianoli_BankApp.Data;

public class ApplicationDbContext : DbContext
{
  public DbSet<Customer> Customer { get; set; }
  public DbSet<Account> Account { get; set; }
  public DbSet<CreditCard> CreditCard { get; set; }


  protected override void OnConfiguring(DbContextOptionsBuilder options)
  {
    options.UseSqlite("Data Source=bank.db");
  }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {

    modelBuilder.Entity<Customer>()
        .HasMany(c => c.Accounts)
        .WithMany(a => a.Customers)
        .UsingEntity<Dictionary<string, object>>(
            "CustomerAccount",

            right => right
                .HasOne<Account>()
                .WithMany()
                .HasForeignKey("AccountId"),

            left => left
                .HasOne<Customer>()
                .WithMany()
                .HasForeignKey("CustId"),

            join =>
            {
              join.HasKey("CustId", "AccountId");

              join.Property<int>("CustId");
              join.Property<int>("AccountId");
            });



    modelBuilder.Entity<Customer>()
        .HasMany(c => c.CreditCards)
        .WithMany(cc => cc.Customers)
        .UsingEntity<Dictionary<string, object>>(
            "CustomerCreditCard",

            right => right
                .HasOne<CreditCard>()
                .WithMany()
                .HasForeignKey("CardId"),

            left => left
                .HasOne<Customer>()
                .WithMany()
                .HasForeignKey("CustId"),

            join =>
            {
              join.HasKey("CustId", "CardId");

              join.Property<int>("CustId");
              join.Property<int>("CardId");
            });

  }
}