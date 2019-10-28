using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TPS.Domain
{
    public class TPSDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder o)
        {
            o.UseSqlServer("Data Source=localhost;Initial Catalog=TPSDb;Integrated Security=true;");
        }

        protected override void OnModelCreating(ModelBuilder b)
        {
            //Configure City Properties
            b.Entity<City>()
                .Property(c => c.ASCII)
                .HasMaxLength(255)
                .IsRequired(true);

            b.Entity<City>()
                .Property(c => c.Code)
                .HasMaxLength(255)
                .IsRequired(true);

            b.Entity<City>()
               .Property(c => c.Country)
               .HasMaxLength(255)
               .IsRequired(true);

            b.Entity<City>()
               .Property(c => c.Name)
               .HasMaxLength(255)
               .IsRequired(true);

            //Configure Travel Package Properties
            b.Entity<TravelPackage>()
                .Property(tp => tp.Name)
                .HasMaxLength(255)
                .IsRequired();

            b.Entity<TravelPackage>()
             .Property(tp => tp.Description)
             .IsRequired();

            b.Entity<TravelPackage>()
             .Property(tp => tp.StatusId)
             .HasDefaultValueSql("1");

            //Configure Concatenate Key for Customer Travel Package
            b.Entity<CustomerTravelPackage>()
                .HasKey(ctp => new { ctp.CustomerId, ctp.TravelPackageId });
            
            //Configure Non Mapped Properties for Travel Provider
            b.Entity<TravelProvider>()
                .Ignore(tp => tp.Customers)
                .Ignore(tp => tp.Employees);

            //Configure Concatenate Key for Travel Package City 
            b.Entity<TravelPackageCity>()
                .HasKey(tpc => tpc.Id);

            //Configure Concatenate Key for Travel Package City Attraction
            b.Entity<TravelPackageCityAttraction>()
                .HasKey(tpca => new { tpca.CityAttractionId, tpca.TravelPackageCityId });


            b.Entity<TravelPackageCityAttraction>()
              .HasOne(tpca => tpca.CityAttraction)
              .WithMany(ca => ca.TravelPackageCityAttractions);

            b.Entity<TravelPackageCityAttraction>()
                 .HasOne(tpca => tpca.TravelPackageCity)
                 .WithMany(tpc=>tpc.TravelPackageCityAttractions);


            //Configure Person Inheritance
            b.Entity<Person>()
                .HasDiscriminator<string>("PersonType")
                .HasValue<Person>("Person")
                .HasValue<Employee>("Employee")
                .HasValue<Customer>("Customer");

            b.Entity<Person>()
                .Property(p => p.Forename)
                .HasMaxLength(255)
                .IsRequired(true);
            b.Entity<Person>()
              .Property(p => p.Surname)
              .HasMaxLength(255)
              .IsRequired(true);



            //Configure Payment Inheritance
            b.Entity<Payment>()
                .HasDiscriminator<string>("PaymentType")
                .HasValue<Payment>("Payment")
                .HasValue<BitcoinPayment>("Bitcoin")
                .HasValue<CreditCardPayment>("CreditCard")
                .HasValue<PayPalPayment>("PayPal");

            //Configure Payment Generated Value (DateTime)
            b.Entity<Payment>()
                .Property(p => p.DateTime)
                .HasDefaultValueSql("getdate()");

            //Configure Voucher Generated Value (Expires)
            b.Entity<Voucher>()
                .Property(v => v.Expires)
                .HasDefaultValueSql("DATEADD(month, 3, GETDATE())");
         

        }
        public DbSet<City> Cities { get; set; }
        public DbSet<CityAttraction> CityAttractions { get; set; }
        public DbSet<CustomerTravelPackage> CustomerTravelPackages { get; set; }
        public DbSet<Payment>  Payments { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<TravelPackage> TravelPackages { get; set; }
        public DbSet<TravelPackageCity> TravelPackageCities { get; set; }
        public DbSet<TravelPackageCityAttraction> TravelPackageCityAttractions { get; set; }
        public DbSet<TravelProvider> TravelProviders { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }

    }
}
