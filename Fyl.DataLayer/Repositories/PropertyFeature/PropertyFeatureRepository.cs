using Fyl.Entities;
using Fyl.Library.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.DataLayer.Repositories
{
    public class PropertyFeatureRepository
    {
        public IFylEntities _entities;

        public PropertyFeatureRepository(IFylEntities entities)
        {
            _entities = entities;
        }

        public List<PropertyFeatureEnum> GetPropertyFeatures(Guid propertyId)
        {
            var features = _entities.PropertyFeatures
                .Where(w => w.PropertyId == propertyId)
                .Select(s => s.Feature)
                .ToList();

            return features;
        }
    }
}
