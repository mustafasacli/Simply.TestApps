using Mst.Project.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

namespace Mst.Project.CoreContext
{
    /// <summary>
    /// Defines the <see cref="ClassicmodelsCoreDbContext"/>.
    /// </summary>
    public class ClassicmodelsCoreDbContext : DbContext
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle("#CONNECTION_STRING#");
        }

        /// <summary>
        /// The OnModelCreating method.
        /// </summary>
        /// <param name="modelBuilder">The modelBuilder<see cref="ModelBuilder"/>.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("classicmodels");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClassicmodelsCoreDbContext).Assembly);

            /**
             * Ef Core Entity type 'XXX' has composite primary key defined with data annotations. To set composite primary key, use fluent API.
             * hatasý için sýnýfta birden fazla Key attribute  varsa onlarý tanýmlamak gerekiyor ve bu iþlem aþaðýda yapýlýyor.
             */
            //modelBuilder.Entity<KullaniciKullanicirol>().HasKey(c => new { c.KullaniciFk, c.RolFk });
            //modelBuilder.Entity<KullaniciRoluygulama>().HasKey(c => new { c.UygulamaFk, c.RolFk });


            #region [ Ignoring Tables Have No Key property ]

            var types = new List<Type>();

            this.GetType()
            .GetRuntimeProperties()
            .Where(o =>
                o.PropertyType.IsGenericType &&
                o.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>) &&
                o.PropertyType.GenericTypeArguments.Count() > 0)
                .Select(q => q.PropertyType.GenericTypeArguments)
                .ToList()
                .ForEach(q =>
                {
                    types.AddRange(q);
                });
            types = types.Distinct().ToList();
            types =
            types.Where(q => !q.GetProperties().Any(p => p.GetCustomAttribute<KeyAttribute>() != null))
            .ToList() ?? new List<Type>();

            types.ForEach(q => { modelBuilder.Ignore(q); });

            # endregion [ Ignoring Tables Have No Key property ]

            #region [ Mapping Entities To Tables ]
/*

*/
            #endregion [ Mapping Entities To Tables ]

            // Attaki kýsým viewleri belirtmede kullanýlacak.
            #region [ Mapping Entities To Views ]
            var views = new List<Type>();

            this.GetType()
            .GetRuntimeProperties()
            .Where(o =>
                o.PropertyType.IsGenericType &&
                o.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>) &&
                //o.PropertyType.GenericTypeArguments.Count() > 0)
                o.PropertyType.GenericTypeArguments.Any())
                .Select(q => q.PropertyType.GenericTypeArguments)
                .ToList()
                .ForEach(q =>
                {
                    views.AddRange(q.Where(p => p.Name.ToLowerInvariant().StartsWith("vw")).ToArray());
                });
            views.ForEach(viewType =>
            {
                if (viewType.GetProperties().Any(q => q.GetCustomAttribute<KeyAttribute>() != null))
                {
                    modelBuilder
            .Entity(viewType)
            .ToView(viewType.GetCustomAttribute<TableAttribute>()?.Name ?? viewType.Name)
            .HasKey(viewType.GetProperties().Where(q => q.GetCustomAttribute<KeyAttribute>() != null).Select(q => q.Name).ToArray());
                }
                else
                {
                    modelBuilder
            .Entity(viewType)
            .ToView(viewType.GetCustomAttribute<TableAttribute>()?.Name ?? viewType.Name)
            .HasNoKey();
}

            #endregion [ Mapping Entities To Views ]
        }

        #region [ Tables List ]

        /// <summary>
        /// Gets or sets the Customers.
        /// </summary>
        public virtual DbSet<Customers> Customers
        { get; set; }

        /// <summary>
        /// Gets or sets the Employees.
        /// </summary>
        public virtual DbSet<Employees> Employees
        { get; set; }

        /// <summary>
        /// Gets or sets the Offices.
        /// </summary>
        public virtual DbSet<Offices> Offices
        { get; set; }

        /// <summary>
        /// Gets or sets the Orderdetails.
        /// </summary>
        public virtual DbSet<Orderdetails> Orderdetails
        { get; set; }

        /// <summary>
        /// Gets or sets the Orders.
        /// </summary>
        public virtual DbSet<Orders> Orders
        { get; set; }

        /// <summary>
        /// Gets or sets the Payments.
        /// </summary>
        public virtual DbSet<Payments> Payments
        { get; set; }

        /// <summary>
        /// Gets or sets the Productlines.
        /// </summary>
        public virtual DbSet<Productlines> Productlines
        { get; set; }

        /// <summary>
        /// Gets or sets the Products.
        /// </summary>
        public virtual DbSet<Products> Products
        { get; set; }

        #endregion [ Tables List ]
    }
}