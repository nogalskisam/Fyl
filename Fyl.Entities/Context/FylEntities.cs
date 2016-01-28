using Fyl.Entities.Migrations;
using log4net;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Entities
{
    public class FylEntities : DbContext, IFylEntities
    {
        private ILog _Logger;

        // User Stuff
        public IDbSet<User> Users { get; set; }

        public IDbSet<Session> Sessions { get; set; }

        public IDbSet<UserAuthentication> UserAuthentications { get; set; }

        // Practical Data

        public IDbSet<Address> Addresses { get; set; }

        public IDbSet<Property> Properties { get; set; }

        //public IDbSet<User> Users { get; set; }

        //public IDbSet<PasswordAuthorisation> PasswordAuthorisations { get; set; }

        public ILog Logger
        {
            get
            {
                if (_Logger == null)
                {
                    _Logger = LogManager.GetLogger(typeof(FylEntities));
                }

                return _Logger;
            }
            set
            {
                _Logger = value;
            }
        }

        public FylEntities()
            : base("FylEntities")
        { }

        public FylEntities(string nameOrConnectionString)
            : base(nameOrConnectionString)
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ConfigureModel(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        public static void ConfigureModel(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<User>()
                .HasMany<Session>(u => u.Sessions)
                .WithRequired(s => s.User)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<User>()
                .HasOptional<UserAuthentication>(u => u.Authentication)
                .WithRequired(a => a.User)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Property>()
                .HasRequired<User>(u => u.Landlord)
                .WithRequiredPrincipal();
        }

        /// <summary>
        /// Creates the database.
        /// </summary>
        public static void DropAndCreateDatabase(string serverName, string databaseName)
        {
            var connectionString = string.Format("Data Source={0};Integrated Security=SSPI;Initial Catalog={1}", serverName, databaseName);
            Database.SetInitializer<FylEntities>(null);
            using (var entities = new FylEntities(connectionString))
            {
                if (entities.Database.Exists())
                {
                    entities.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, string.Format("ALTER DATABASE {0} SET SINGLE_USER WITH ROLLBACK IMMEDIATE", databaseName));
                    entities.Database.Delete();
                }
            }

            MigrateDatabase(serverName, databaseName);
        }

        /// <summary>
        /// Updates the database to the latest migration.
        /// </summary>
        /// <param name="serverName">Name of the database server.</param>
        /// <param name="databaseName">Name of the database.</param>
        public static void MigrateDatabase(string serverName, string databaseName)
        {
            var migrator = new DbMigrator(new Configuration(serverName, databaseName));
            migrator.Update();
        }

        /// <summary>
        /// Creates the database if it doesn't exists and then applies the migrations
        /// </summary>
        public static void CreateOrUpdate()
        {
            var dbMigrator = new DbMigrator(new Configuration());
            dbMigrator.Update();
        }

        public void SetModified(object itemWithChanges)
        {
            Entry(itemWithChanges).State = EntityState.Modified;
        }

        public void SetPropertyModified(object itemWithChanges, string propertyName)
        {
            Entry(itemWithChanges).Property(propertyName).IsModified = true;
        }

        public void SetState<T>(T entity, EntityState state) where T : class
        {
            Entry<T>(entity).State = state;
        }

        public void SetPropertyModified<T>(T entity, string property, bool modified) where T : class
        {
            Entry<T>(entity).Property<T>(property).IsModified = modified;
        }

        public void Delete<TEntity>(TEntity entry) where TEntity : class
        {
            Entry(entry).State = EntityState.Deleted;
        }

        public static void DropDatabase(string databaseName, string connectionString)
        {
            using (var entities = new FylEntities(connectionString))
            {
                if (entities.Database.Exists())
                {
                    entities.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, string.Format("ALTER DATABASE {0} SET SINGLE_USER WITH ROLLBACK IMMEDIATE", databaseName));
                    entities.Database.Delete();
                }
            }
        }

        public override int SaveChanges()
        {
            return SaveChanges(this.Logger);
        }

        public override async Task<int> SaveChangesAsync()
        {
            return await SaveChangesAsync(this.Logger);
        }

        public int SaveChanges(ILog logger)
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException vex)
            {
                string message = HandleDbEntityValidationException(logger, vex);
                throw new DbEntityValidationException(message, vex);
            }
            catch (DbUpdateConcurrencyException cex)
            {
                var message = HandleDbUpdateConcurrencyException(logger, cex);
                throw;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                throw;
            }
        }

        public Task<int> SaveChangesAsync(ILog logger)
        {
            try
            {
                return base.SaveChangesAsync();
            }
            catch (DbEntityValidationException vex)
            {
                string message = HandleDbEntityValidationException(logger, vex);
                throw new DbEntityValidationException(message, vex);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw;
            }
        }

        private static string HandleDbEntityValidationException(ILog logger, DbEntityValidationException vex)
        {
            var builder = new StringBuilder();
            builder.AppendLine("A DbEntityValidationException was caught saving changes.");

            try
            {
                foreach (DbEntityValidationResult result in vex.EntityValidationErrors)
                {
                    foreach (DbValidationError error in result.ValidationErrors)
                    {
                        builder.AppendLine(string.Format("Type: {0}; Property: {1}; Message: {2}", result.Entry.Entity.GetType(), error.PropertyName, error.ErrorMessage));
                    }
                }
            }
            catch (Exception e)
            {
                builder.Append("Error parsing DbEntityValidationException: " + e.ToString());
            }

            string message = builder.ToString().TrimEnd(new[] { '\r', '\n' });

            logger.Error(message);

            return message;
        }

        private static string HandleDbUpdateConcurrencyException(ILog logger, DbUpdateConcurrencyException cex)
        {
            var builder = new StringBuilder("A DbUpdateConcurrencyException was caught saving changes.\r\n");

            try
            {
                foreach (DbEntityEntry entry in cex.Entries)
                {
                    var originalValues = new Dictionary<string, string>();
                    foreach (var propertyName in entry.OriginalValues.PropertyNames)
                    {
                        originalValues.Add(propertyName, entry.OriginalValues.GetValue<object>(propertyName).ToString());
                    }

                    var currentValues = new Dictionary<string, string>();
                    if (!(entry.State == EntityState.Deleted))
                    {
                        try
                        {
                            foreach (var propertyName in entry.CurrentValues.PropertyNames)
                            {
                                currentValues.Add(propertyName, entry.CurrentValues.GetValue<object>(propertyName).ToString());
                            }
                        }
                        catch (Exception ex)
                        {
                            currentValues.Add("Error", "Error getting the current values");
                            logger.Error(ex);
                        }
                    }
                    else
                    {
                        currentValues.Add("All", "There are none because it is deleted");
                    }

                    builder.AppendLine(string.Format("Entity: {0}; State: {1}; Original Values: {2}; Current Values; {3}", entry.Entity.GetType().ToString(), entry.State.ToString(), string.Join(",", originalValues.Select(t => "{ " + t.Key + " : " + t.Value + " }")), string.Join(",", currentValues.Select(t => "{ " + t.Key + " : " + t.Value + " }"))));
                }
            }
            catch (Exception e)
            {
                builder.Append("Error parsing DbUpdateConcurrencyException: " + e.ToString());
            }

            string message = builder.ToString().TrimEnd(new[] { '\r', '\n' });

            logger.Error(message, cex);

            return message;
        }
    }
}
