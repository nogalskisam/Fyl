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
        // Users
        IDbSet<User> Users { get; set; }

        IDbSet<Session> Sessions { get; set; }

        IDbSet<UserAuthentication> UserAuthentications { get; set; }

        // Practical Data
        IDbSet<Address> Addresses { get; set; }

        IDbSet<Property> Properties { get; set; }

        IDbSet<PropertyImage> PropertyImages { get; set; }

        IDbSet<PropertyFeature> PropertyFeatures { get; set; }

        IDbSet<PropertyRating> PropertyRatings { get; set; }

        IDbSet<PropertySignRequest> PropertySignRequests { get; set; }

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
