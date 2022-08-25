using Mst.Project.Entity;
using SimpleFileLogging.Enums;
using SimpleFileLogging.Interfaces;
using Coddie.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;

namespace Mst.Project.Context
{
    /// <summary>
    /// Defines the <see cref="ClassicmodelsDbContext"/>.
    /// </summary>
    public class ClassicmodelsDbContext : DbContext
    {
        /// <summary>
        /// Defines the logger.
        /// </summary>
        private readonly ISimpleLogger logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClassicmodelsDbContext"/> class.
        /// </summary>
        public ClassicmodelsDbContext() : base($"name={nameof(ClassicmodelsDbContext)}")
        {
            Database.SetInitializer<ClassicmodelsDbContext>(null);
            logger =
            SimpleFileLogging.SimpleFileLogger.Instance;
            logger.LogDateFormatType = SimpleLogDateFormats.None;
            this.Database.Log = LogQueries;
        }

        /// <summary>
        /// The LogQueries
        /// </summary>
        /// <param name="q">The q <see cref="string"/>.</param>
        protected void LogQueries(string q)
        {
            logger?.Debug(q);
        }

        /// <summary>
        /// The OnModelCreating method.
        /// </summary>
        /// <param name="modelBuilder">The modelBuilder<see cref="DbModelBuilder"/>.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("classicmodels");
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());

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
            types.Where(q => q.GetKeysOfType().Count() < 1)
            .ToList() ?? new List<Type>();
            modelBuilder.Ignore(types);

            # endregion [ Ignoring Tables Have No Key property ]

            #region [ Mapping Entities To Tables ]



            # endregion [ Mapping Entities To Tables ]
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