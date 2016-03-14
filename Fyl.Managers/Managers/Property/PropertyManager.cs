using Fyl.DataLayer.Repositories;
using Fyl.Library.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Managers
{
    public class PropertyManager : IPropertyManager
    {
        private readonly IPropertyRepository _propertyRepository;

        public PropertyManager(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public PropertyListResponseDto GetAvailablePropertiesForList(PropertyListRequestDto request)
        {
            var items = _propertyRepository.GetAvailablePropertiesForListItems(request);
            var count = _propertyRepository.GetAvailablePropertiesForListCount(request);

            var result = new PropertyListResponseDto()
            {
                Items = items,
                Count = count
            };

            return result;
        }
    }
}
