using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Entities
{
    public interface IFylEntities
    {
        IDbSet<Landlord> Landlords { get; set; }

        IDbSet<Address> Addresses { get; set; }

        IDbSet<Property> Properties { get; set; }

        IDbSet<Tenant> Tenants { get; set; }

        IDbSet<User> Users { get; set; }

        IDbSet<PasswordAuthorisation> PasswordAuthorisations { get; set; }

        Database Database { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync();

        void SetModified(object itemWithChanges);

        void SetPropertyModified(object itemWithChanges, string propertyName);

        void SetState<T>(T entity, EntityState state) where T : class;

        void SetPropertyModified<T>(T entity, string property, bool modified) where T : class;

        void Delete<TEntity>(TEntity entry) where TEntity : class;
    }
}
