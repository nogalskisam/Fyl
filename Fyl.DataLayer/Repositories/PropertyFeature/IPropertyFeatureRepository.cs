using Fyl.Library.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.DataLayer.Repositories
{
    public interface IPropertyFeatureRepository
    {
        List<PropertyFeatureEnum> GetPropertyFeatures(Guid propertyId);
    }
}
